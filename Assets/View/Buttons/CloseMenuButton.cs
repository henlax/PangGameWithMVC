using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenuButton : PangElement
{
    public void OnClick()
    {
        App.Controller.Menu.CloseMenu();
    }
}
