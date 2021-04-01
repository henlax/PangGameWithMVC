using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardInputView : PangElement
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            App.Controller.Player.Shoot();
        }

        if (Input.GetKey(KeyCode.LeftArrow)) App.Controller.Player.Move(-1);
        if (Input.GetKey(KeyCode.RightArrow)) App.Controller.Player.Move(1);

        if (Input.GetKeyUp(KeyCode.LeftArrow)) App.Controller.Player.Move(0);
        if (Input.GetKeyUp(KeyCode.RightArrow)) App.Controller.Player.Move(0);

    }
}
