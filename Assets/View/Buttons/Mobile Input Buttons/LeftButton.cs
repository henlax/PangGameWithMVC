using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : PangElement, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        App.Controller.Player.Move(0);
    }

    private void Update()
    {
        if(buttonPressed) App.Controller.Player.Move(-1);
    }
}
