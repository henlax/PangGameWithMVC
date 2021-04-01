using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerView : PangElement
{
    public Rigidbody2D Rigidbody2D;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void StartPlayer(float playerStartingPosition)
    {
        (App.View.Player.transform as RectTransform).anchoredPosition = new Vector2(playerStartingPosition, 0);
    }

    public void Move(float input)
    {
        Vector2 move = new Vector2(input * App.Model.PlayerSpeed * 50 * App.Model.CanvasScale, 0);
        Rigidbody2D.velocity = move;
    }

    public float GetPosition() => (App.View.Player.transform as RectTransform).anchoredPosition.x;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Balls"))
        {
            App.Controller.Player.OnBallHit();
        }
    }

    public void StopPlayer() => Rigidbody2D.velocity = Vector2.zero; 

}
