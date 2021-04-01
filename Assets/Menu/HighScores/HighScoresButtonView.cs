using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoresButtonView : PangMenuElement
{
    public void OnClick()
    {
        App.Controller.ShowHighScoreView();
    }
}
