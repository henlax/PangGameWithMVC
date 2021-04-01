using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : PangElement
{
    public void StartLevel()
    {
        if (App.Model.levlesDB.HasLevel())
        {
            BuildLevel();
        }
        else
        {
            GameOver("You Won");
        }
    }

    private void BuildLevel()
    {
        ClearLevel();

        var level = App.Model.levlesDB.GetLevel();

        level.Balls.ForEach(App.Controller.Ball.CreateBall);
        App.View.Player.StartPlayer(level.PlayerStartingPosition);
        App.View.Info.Lives.text = "Lives: "+ App.Model.Lives;
        UpdateScore();

    }

    public void UpdateScore()
    {
        App.View.Info.Score.text = "Score: " + App.Model.score;
    }

    private void ClearLevel()
    {
        FindObjectOfType<PlayerView>().Rigidbody2D.velocity = Vector2.zero;
        FindObjectsOfType<BallView>().ToList().ForEach(ball => Destroy(ball.gameObject));
        FindObjectsOfType<VineView>().ToList().ForEach(ball => Destroy(ball.gameObject));
    }

    public bool LevelWinCondition() => FindObjectsOfType<BallView>().Length == 0;

    public void NextLevel()
    {
        App.Model.LevelNumber++;
        StartLevel();
    }

    public void GameOver(string messege)
    {
        Pause();
        App.View.DiedScreen.Messege.text = messege;
        if (HighScroresUtil.CheckIfHighScore(App.Model.score))
        {
            App.View.EnterName.gameObject.SetActive(true);           
        }
        else
        {
            App.View.DiedScreen.gameObject.SetActive(true);
        }    
    }


    public void DoneEnteringName()
    {
        if (string.IsNullOrWhiteSpace(App.View.EnterName.Input.text)) return;

        HighScroresUtil.AddNewHighScore(App.Model.score, App.View.EnterName.Input.text);

        App.View.EnterName.gameObject.SetActive(false);
        App.View.DiedScreen.gameObject.SetActive(true);
    }


    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        App.Controller.Ball.PauseBalls();
        App.Controller.Vines.PauseVines();
        App.Controller.Player.PausePlayer();
        App.View.Input.enabled = false;
    }

    public void Resume()
    {
        App.Controller.Ball.ResumeBalls();
        App.Controller.Vines.ResumeVines();
        App.Controller.Player.ResumePlayer();
        App.View.Input.enabled = true;
    }

    internal void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}