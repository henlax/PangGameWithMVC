using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMenuButton : PangElement
{
    public void OnClick()
    {
        App.Controller.Level.Restart();
    }
}