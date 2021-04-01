using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuButton : PangElement
{
    public void OnClick()
    {
        App.Controller.Menu.OpenMenu();
    }
}
