using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerInfo : UI_Scene
{
    enum Images
    {
        HPBarBG,
        HPBar,
        STAMINABarBG,
        STAMINABar,
    }

    Charater _player;

    public void SetInfo(Charater player)
    {
        _player = player;
        return;
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));

        Refresh();
    }

    public void Refresh()
    {
        if (_player == null)
            return;

        Image HpBariamge = GetImage((int)Images.HPBar);
        HpBariamge.fillAmount = _player.CurrentHp / _player.MaxHp;
        Image StaminaBariamge = GetImage((int)Images.STAMINABar);
        StaminaBariamge.fillAmount = _player.CurrentStamina / _player.MaxStamina;
    }
}
