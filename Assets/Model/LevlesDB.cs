using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevlesDB : PangElement
{
    public List<Level> Levels;

    public Level GetLevel()
    {
        if (App.Model.LevelNumber >= Levels.Count)
        {
            Debug.LogError("There was an error while building level");
            Application.Quit();
        }

        return Levels[App.Model.LevelNumber];
    }

    public bool HasLevel() => App.Model.LevelNumber < Levels.Count;

}

[System.Serializable]
public class Level
{
    public string Name;
    public List<Ball> Balls;
    public float PlayerStartingPosition;
    public float XVelocity;
}

[System.Serializable]
public class Ball
{
    public Vector2 StartingPosiotion;
    public float StartingYVelocity;
    public int Size;
    public int BallDirection=1;
}