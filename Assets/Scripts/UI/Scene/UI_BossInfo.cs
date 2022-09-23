using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BossInfo : UI_Scene
{
    enum Images
    {
        BossHpBar
    }

    Charater _boss;

    public void SetInfo(Charater Boss)
    {
        _boss = Boss;
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));

        Refresh();
    }

    public void Refresh()
    {
        if (_boss == null)
            return;

        Image HpBariamge = GetImage((int)Images.BossHpBar);
        HpBariamge.fillAmount = _boss.Hp / _boss.MaxHp;
    }
}
