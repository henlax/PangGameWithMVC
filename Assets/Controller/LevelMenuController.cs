using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : PangElement
{
    public void OpenMenu()
    {
        App.Controller.Level.Pause();
        App.View.Menu.MenuGameObject.SetActive(true);
        App.View.Menu.OpenMenuButton.gameObject.SetActive(false);
    }

    public void CloseMenu()
    {
        App.View.Menu.MenuGameObject.SetActive(false);
        App.View.Menu.OpenMenuButton.gameObject.SetActive(true);
        App.Controller.Level.Resume();
    }
}