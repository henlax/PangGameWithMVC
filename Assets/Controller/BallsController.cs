using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallsController : PangElement
{

    public void CreateBall(Ball ball)
    {
        var ballGO = Instantiate(App.Model.BallPrefab, App.View.BallContainer);

        ballGO.transform.localPosition = ball.StartingPosiotion;

        var ballSize = ball.Size * App.Model.BallSizeMultiplyer;
        ((RectTransform)ballGO.transform).sizeDelta = Vector2.one * ballSize;

        ballGO.GetComponent<CircleCollider2D>().radius = ballSize / 2;
        ballGO.GetComponent<Rigidbody2D>().velocity = new Vector3(App.Model.levlesDB.GetLevel().XVelocity* ball.BallDirection, ball.StartingYVelocity);

    }

    public void OnBallPop(BallView ballView)
    {
        //if can pop to smaller balls
        if (ballView.GetBallSize() > 1)
        {
            var leftBall = new Ball()
            {
                Size = ballView.GetBallSize() - 1,
                StartingPosiotion = ballView.transform.localPosition,
                StartingYVelocity = ballView.rigidbody2d.velocity.y,
                BallDirection = -1
            };

            var rightBall = new Ball()
            {
                Size = ballView.GetBallSize() - 1,
                StartingPosiotion = ballView.transform.localPosition,
                StartingYVelocity = ballView.rigidbody2d.velocity.y,
                BallDirection =1
            };

            CreateBall(leftBall);
            CreateBall(rightBall);
        }

        Destroy(ballView.gameObject);
    }

    public void PauseBalls() => FindObjectsOfType<BallView>().ToList().ForEach(ball => ball.rigidbody2d.simulated = false);

    public void ResumeBalls() => FindObjectsOfType<BallView>().ToList().ForEach(ball => ball.rigidbody2d.simulated = true);


    public void OnBallDestroyed()
    {
        if (App.Controller.Level.LevelWinCondition()) App.Controller.Level.NextLevel();
    }
}