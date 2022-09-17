using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_BattleManager : MonoBehaviour
{
    public JoyStick2 JOYSTICK;

    public void OnPointerDown(BaseEventData evt)
    {
        JOYSTICK.gameObject.SetActive(true);


#if UNITY_ANDROID
    #if UNITY_EDITOR
        JOYSTCK.transform.position = input.mousePosition;
    #else
        Touch touch = Input.GetTouch(0);

        JOYSTICK.tranform.position = touch.position;
    #endif
        JOYSTICK.OnDown((PointerEventData)evt);

#endif
        JOYSTICK.OnDown((PointerEventData)evt);

    }


    public void OnPointerUp(BaseEventData evt)
    {
        JOYSTICK.gameObject.SetActive(false);
        JOYSTICK.OnUp((PointerEventData)evt);
    }

    public void OnDrag(BaseEventData evt)
    {
        JOYSTICK.OnDrag((PointerEventData)evt);
    }
}
