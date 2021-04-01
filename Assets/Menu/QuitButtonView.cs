using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonView : PangMenuController
{
    public void OnClick()
    {
        App.Controller.Quit();
    }
}
