using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerInfo : UI_Scene
{
    enum Images
    {
        HPBarBG,
        HPBarBGHit,
        HPBar,
        STAMINABarBG,
        STAMINABar,
    }

    enum Texts
    {
        Name
    }

    Charater _player;

    public void SetInfo(Charater player)
    {
        _player = player;
        Refresh();
    }

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<TextMeshPro>(typeof(Texts));
    }

    public void Refresh()
    {
        if (_player == null)
            return;

        Image HpBariamge = GetImage((int)Images.HPBar);
        HpBariamge.fillAmount = _player.Hp / _player.MaxHp;
        Image StaminaBariamge = GetImage((int)Images.STAMINABar);
        StaminaBariamge.fillAmount = _player.Stamina / _player.MaxStamina;
    }

    public void HitEvent()
    {
        StartCoroutine(DownHP());
    }

    public IEnumerator DownHP()
    {
        Refresh();

        yield return new WaitForSeconds(0.5f);

        Image HpBarBGHitiamge = GetImage((int)Images.HPBarBGHit);

        while (true)
        {
            HpBarBGHitiamge.fillAmount -= Time.deltaTime;
            if (HpBarBGHitiamge.fillAmount <= _player.Hp / _player.MaxHp)
            {
                HpBarBGHitiamge.fillAmount = _player.Hp / _player.MaxHp;
                break;
            }

            yield return null;
        }
    }
}
