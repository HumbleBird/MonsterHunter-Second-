using UnityEngine;

public class Battle : Strategy
{
    GameObject go;

    public override void Init()
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnAttacked(GameObject attacker, int dmg, GameObject victim)
    {

        Charater victimCharater = victim.GetComponent<Charater>();
        Charater attackerCharater = attacker.GetComponent<Charater>();

        int damage = (int)Mathf.Max(0, attackerCharater.Atk - victimCharater.Def);
        victimCharater.Hp -= damage;

        // TODO 애니메이션
        victimCharater._animator.Play("Hit");

        if (victimCharater.Hp <= 0)
        {
            victimCharater.Hp = 0;
            victimCharater.State = Define.CreatureState.Dead;
        }
    }

    protected virtual void OnHitEvent() { }
}
