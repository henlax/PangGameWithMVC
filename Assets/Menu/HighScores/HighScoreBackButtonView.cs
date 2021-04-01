using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreBackButtonView : PangMenuElement
{
    public void OnClick()
    {
        App.Controller.CloseHighScores();
    }
}
