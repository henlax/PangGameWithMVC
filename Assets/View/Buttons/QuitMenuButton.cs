using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenuButton : PangElement
{
    public void OnClick()
    {
        App.Controller.Level.QuitToMainMenu();
    }
}
