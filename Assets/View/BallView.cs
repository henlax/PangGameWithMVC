using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(CircleCollider2D))]
public class BallView : PangElement
{
    public Rigidbody2D rigidbody2d;
    private RectTransform rectTransform;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        if (rigidbody2d == null)
        {
            Debug.LogError("Issue with creating the balls");
            Application.Quit();
        }

        rectTransform = GetComponent<RectTransform>();
    }

    public void PopBall()
    {
        App.Controller.Ball.OnBallPop(this);
    }

    //Used fixed update because of changing physics parameters
    private void FixedUpdate()
    {
        var maxYVelocity = App.Model.GetMaxVelocity(GetBallSize()) * App.Model.CanvasScale;
        if (rigidbody2d.velocity.y > maxYVelocity )
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, maxYVelocity);
        }
    }

    private void OnDestroy()
    {
        //Check if OnDestroy is called because the scene is closing
        if (gameObject.scene.isLoaded)
            App.Controller.Ball.OnBallDestroyed();
    }

    public int GetBallSize() => (int) rectTransform.sizeDelta.x / App.Model.BallSizeMultiplyer;
}