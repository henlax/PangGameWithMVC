using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PangController : PangElement
{
    public LevelController Level;
    public LevelMenuController Menu;
    public BallsController Ball;
    public VinesController Vines;
    public PlayerController Player;

    private void Start()
    {
        App.Model.CanvasScale = FindObjectOfType<Canvas>().scaleFactor;
        Level.StartLevel();
    }
}
