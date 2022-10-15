using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_BattleManager : IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public JoyStick2 JOYSTICK;

    public void OnPointerDown(PointerEventData evt)
    {
        JOYSTICK.gameObject.SetActive(true);


#if UNITY_ANDROID
    #if UNITY_EDITOR
        //JOYSTCK.transform.position = input.mousePosition;
    #else
        Touch touch = Input.GetTouch(0);

        JOYSTICK.tranform.position = touch.position;
    #endif
        JOYSTICK.OnDown((PointerEventData)evt);

#endif
        JOYSTICK.OnDown((PointerEventData)evt);

    }


    public void OnPointerUp(PointerEventData evt)
    {
        JOYSTICK.gameObject.SetActive(false);
        JOYSTICK.OnUp((PointerEventData)evt);
    }

    public void OnDrag(PointerEventData evt)
    {
        JOYSTICK.OnDrag((PointerEventData)evt);
    }
}
