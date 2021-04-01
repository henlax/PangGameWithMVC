using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonView : PangMenuElement
{
    public void OnClick()
    {
        App.Controller.StartGame();
    }
}
