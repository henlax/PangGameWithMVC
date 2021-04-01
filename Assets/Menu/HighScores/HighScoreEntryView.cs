using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreEntryView : PangMenuElement
{
    public Text Name;
    public Text Score;

    public void SetData(HighScoreEntry entry)
    {
        Name.text = entry.name;
        Score.text = entry.score.ToString();
    }
}