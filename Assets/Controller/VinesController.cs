using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VinesController : PangElement
{
    public void CreateVine(float x)
    {
        if (VineAlreadyExist()) return;

        var vineGO = Instantiate(App.Model.VinePrefab, App.View.VineContainer);
        var rectTransform = vineGO.transform as RectTransform;
        rectTransform.anchoredPosition = new Vector2(x, rectTransform.anchoredPosition.y);
    }

    public void HitBall(BallView ball)
    {
        App.Model.AddScore(App.Model.GetScore(ball.GetBallSize()));

        ball.PopBall();
    }

    private bool VineAlreadyExist() => FindObjectsOfType<VineView>().Length > 0;

    public void PauseVines()
    {
        FindObjectsOfType<VineView>().ToList().ForEach(vine => vine.enabled = false);
    }

    public void ResumeVines()
    {
        FindObjectsOfType<VineView>().ToList().ForEach(vine => vine.enabled = true);
    }
}