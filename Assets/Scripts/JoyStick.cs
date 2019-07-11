using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //Event click vao screen

public class JoyStick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    // IPointerUpHandler user ko nhan vao button
    // IPointerDownHandler user nhan vao button

    private Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left Button")
        {
            Debug.Log("Left Button");
            player.SetMoveLeft(true);
        } else
        {
            player.SetMoveLeft(false);
            Debug.Log("Right");
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        player.StopMoving();
    }

}
