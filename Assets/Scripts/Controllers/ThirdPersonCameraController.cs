using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    CinemachineFreeLook m_cinemashin;
    Transform m_goPlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_cinemashin = GetComponent<CinemachineFreeLook>();
        Init();
    }

    void Init()
    {
        m_goPlayer = Managers.Object.Find(1).transform.Find("Third Person Player");
        m_cinemashin.Follow = m_goPlayer;
        m_cinemashin.LookAt = m_goPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
