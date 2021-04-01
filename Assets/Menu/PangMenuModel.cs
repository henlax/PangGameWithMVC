using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PangMenuModel : PangMenuElement
{
    public int StartScene =1;
    public List<HighScoreEntry> HighScores;
    public GameObject HighScoreEntryPrefab;

    private void Start()
    {
        HighScores = HighScroresUtil.GetHighScores();
    }
}

