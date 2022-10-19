using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Define;

public partial class AI : Charater
{
    public override void SetInfo(int id) { }

    #region 변수
    NavMeshAgent navMeshAgent;                      //  Nav mesh agent component
    public float startWaitTime = 4;                 //  Wait time of every action
    public float timeToRotate = 2;                  //  Wait time when the enemy detect near the player without seeing
    float m_WaitTime;                               //  딜레이 대기 시간
    float m_TimeToRotate;                           //  플레이어가 근처에 있을 때 딜레이 대기 시간
    public float speedWalk = 1;                     //  Walking speed, speed in the nav mesh agent
    public float speedRun = 3;                      //  Running speed

    public float viewRadius = 5;                   //  Radius of the enemy view
    public float viewAngle = 90;                    //  Angle of the enemy view

    public float meshResolution = 1.0f;             //  How many rays will cast per degree
    public int edgeIterations = 4;                  //  Number of iterations to get a better performance of the mesh filter when the raycast hit an obstacule
    public float edgeDistance = 0.5f;               //  Max distance to calcule the a minumun and a maximum raycast when hits something
    float m_fDetectRange = 4;

    public Transform[] waypoints;                   //  All the waypoints where the enemy patrols
    int m_CurrentWaypointIndex = 0;                     //  Current waypoint where the enemy is going to

    public LayerMask playerMask;                    //  To detect the player with the raycast
    public LayerMask obstacleMask;                  //  To detect the obstacules with the raycast

    Vector3 playerLastPosition = Vector3.zero;      //  Last position of the player when was near the enemy
    Vector3 m_PlayerPosition = Vector3.zero;        //  Last position of the player when the player is seen by the enemy

    bool m_playerInRange= false;                  //  If the player is in range of vision, state of chasing
    bool m_PlayerNear  = false;               //  If the player is near, state of hearing
    bool m_IsPatrol    = true;             //  If the enemy is patrol, state of patroling
    bool m_CaughtPlayer= false;                 //  if the enemy has caught the player
    #endregion

    void Start()
    {
        m_WaitTime = startWaitTime;                 //  Set the wait time variable that will change
        m_TimeToRotate = timeToRotate;

        navMeshAgent = gameObject.GetOrAddComponent<NavMeshAgent>();

        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speedWalk;             //  Set the navemesh speed with the normal speed of the enemy

        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }

    protected override void UpdateMove()
    {
        StartCoroutine(MoveAI());
    }

    IEnumerator MoveAI()
    {
        while (true)
        {
            if (!m_IsPatrol)
                Chasing();
            else
                Patroling();

            yield return null;
        }
    }

    void Chasing()
    {
        m_PlayerNear = false;                       
        playerLastPosition = Vector3.zero;
        float dis = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (!m_CaughtPlayer)
        {
            Move(speedRun);
            navMeshAgent.SetDestination(m_PlayerPosition);          
        }
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)    
        {
            // 플레이러를 잡지 못하는 상황이라면
            if (m_WaitTime <= 0 && !m_CaughtPlayer && dis >= m_fDetectRange) 
            {
                // 다시 patrol
                m_IsPatrol = true;
                m_PlayerNear = false;
                Move(speedWalk);
                m_TimeToRotate = timeToRotate;
                m_WaitTime = startWaitTime;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
            // 플레이어 앞까지 옴
            else
            {
                if (dis <= 3f)
                {
                    Stop();
                    //CaughtPlayer();
                }
                m_WaitTime -= Time.deltaTime;
            }
        }
    }

    private void Patroling()
    {
        if (m_PlayerNear)
        {
            //  근처 플레이어가 있는지 탐지 후 이동
            if (m_TimeToRotate <= 0)
            {
                Move(speedWalk);
                LookingPlayer(playerLastPosition);
            }
            else
            {
                //  다음 행동과 플레이어의 마지막 위치를 가기 위한 대기
                Stop();
                m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            playerLastPosition = Vector3.zero;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                if (m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    m_WaitTime = startWaitTime;
                }
            }
            else
            {
                NextPoint();
                Move(speedWalk);
            }
        }
    }

    #region 부가 기능
    public void NextPoint()
    {
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }

    void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }

    void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }

    void CaughtPlayer()
    {
        m_CaughtPlayer = true;
        Debug.Break();
        State = CreatureState.Skill;
    }
    #endregion

    void LookingPlayer(Vector3 player)
    {
        navMeshAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 1) // TODO 1을 공격 사정 거리로 바꾸기
        {
            if (m_WaitTime <= 0)
            {
                m_PlayerNear = false;
                Move(speedWalk);
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }

    // 플레이어 있는지 탐지
    void EnviromentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);          
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    // 포착
                    m_playerInRange = true;             
                    m_IsPatrol = false;
                    target = playerInRange[0].gameObject;
                }
                else
                {
                    m_playerInRange = false;
                    target = null;
                }
            }
            // 시야 밖
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
                m_playerInRange = false;               
            if (m_playerInRange)
                m_PlayerPosition = player.transform.position;       
        }
    }
}