using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButton : PangElement
{
    public void OnClick()
    {
        App.Controller.Player.Shoot();
    }
}
