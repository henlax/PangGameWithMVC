using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PangElement
{
    public void OnBallHit()
    {
        App.Model.Lives--;
        if (App.Model.Lives <= 0)
        {
            App.Controller.Level.GameOver("You Died");
        }
        else
        {
            App.Controller.Level.StartLevel();
        }
    }

    public void Move(float input) => App.View.Player.Move(input);

    public void Shoot() => App.Controller.Vines.CreateVine(App.View.Player.GetPosition());

    public void PausePlayer()
    {
        App.View.Player.Rigidbody2D.simulated = false;
    }

    public void ResumePlayer()
    {
        App.View.Player.Rigidbody2D.simulated = true;
    }
}
