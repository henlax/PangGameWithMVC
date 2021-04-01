using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangModel : PangElement
{
    public LevlesDB levlesDB;

    public const int StartingLives = 3;
    public int Lives = StartingLives;
    public int LevelNumber =0;
    public int score = 0;

    public GameObject BallPrefab;
    public GameObject VinePrefab;

    
    public int BallSizeMultiplyer = 20;

    public List<float> MaxVelocityPerSize = new List<float>() { 150, 250 };
    public List<int> ScorePerSize = new List<int>() { 15, 10 };

    public void AddScore(int scoreAddition)
    {
        score += scoreAddition;
        App.Controller.Level.UpdateScore();
    }

    public int BallSizes = 2;

    public float VineSpeed=1.5f;
    public float PlayerSpeed = 1;

    public float CanvasScale;

    private void Start()
    {
        if(MaxVelocityPerSize.Count!= BallSizes || ScorePerSize.Count != BallSizes)
        {
            Debug.LogError("Issue with building Data");
            Application.Quit();
        }
    }

    public float GetMaxVelocity(int ballSize)
    {
        CheckBallSize(ballSize);
        return MaxVelocityPerSize[ballSize - 1];
    }

    public int GetScore(int ballSize)
    {
        CheckBallSize(ballSize);
        return ScorePerSize[ballSize - 1];
    }

    private void CheckBallSize(int ballSize)
    {
        if (ballSize > MaxVelocityPerSize.Count || ballSize < 1)
        {
            Debug.LogError("Bad ball size");
            Application.Quit();
        }
    }
}