using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class BattleManager
{
    #region Player
    void CreatePlayer(int id)
    {
        Table_Player.Info pinfo = Managers.Table.m_Player.Get(id);

        if (pinfo == null)
        {
            Debug.LogError("해당하는 Id의 플레이어가 없습니다.");
            return;
        }

        GameObject go = Managers.Resource.Instantiate(pinfo.m_sPrefabPath);
        Managers.Object.Add(pinfo.m_nID, go);
        go.GetComponent<Charater>().SetInfo(pinfo.m_nID);
    }

    void CreateMonster(int id)
    {
        Table_Boss.Info binfo = Managers.Table.m_Boss.Get(id);

        if (binfo == null)
        {
            Debug.LogError("해당하는 Id의 보스가 없습니다.");
            return;
        }

        GameObject go = Managers.Resource.Instantiate(binfo.m_sPrefabPath);
        Managers.Object.Add(binfo.m_nID, go);
        go.GetComponent<Charater>().SetInfo(binfo.m_nID);
    }

    public void SpawnCharater(CharaterType type)
    {
        switch (type)
        {
            case CharaterType.Player:
                CreatePlayer(1);
                break;
            case CharaterType.Monster:

                break;
            case CharaterType.Boss:
                CreateMonster(101);
                break;
            default:
                break;
        }
    }
    #endregion

    #region Battle
    public virtual void HitEvent(GameObject attacker, float dmg, GameObject victim)
    {
        Charater victimCharater = victim.GetComponent<Charater>();

        int damage = (int)Mathf.Max(0, dmg - victimCharater.Def);
        victimCharater.Hp -= damage;

        if (victimCharater.CompareTag("Player"))
            Managers.UIBattle.HitEvent();

        // TODO 애니메이션
        victimCharater.Animator.Play("Hit");
        Debug.Log($"{victim.name}의 남은 체력은 {victimCharater.Hp}");

        if (victimCharater.Hp <= 0)
        {
            victimCharater.Hp = 0;
            victimCharater.State = Define.CreatureState.Dead;
        }
    }
    #endregion
}
