using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneEnteringName : PangElement
{
    public void OnClick()
    {
        App.Controller.Level.DoneEnteringName();
    }
}
