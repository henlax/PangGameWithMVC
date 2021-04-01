using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HighScroresUtil : MonoBehaviour
{
    private const string HIGH_SCORES_KEY = "HIGH_SCORES";

    //I might be accessing the PlyerPrefs a bit too much, 
    //I could keep it cached on memory and update it whenever I update the PlayerPrefs.
    //But I think it would muddy the code - and we would have this two sources of thruth to always worry about them not syncing
    //And the performance is not that big of an issue

    public static List<HighScoreEntry> GetHighScores()
    {
        List<HighScoreEntry> highScores;

        try
        {
            if (!PlayerPrefs.HasKey(HIGH_SCORES_KEY))
            {
                highScores = new List<HighScoreEntry>();
            }
            else
            {
                var highScoresString = PlayerPrefs.GetString(HIGH_SCORES_KEY);
                highScores = JsonUtility.FromJson<HighScores>(highScoresString).highScoresList;

                if (highScores == null)
                {
                    highScores = new List<HighScoreEntry>();
                }
            }          
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            highScores = new List<HighScoreEntry>();
        }

        return FixHighScoreList(highScores);
    }

    private static List<HighScoreEntry> FixHighScoreList(List<HighScoreEntry> highScores)
    {
        //In case High scores list is unsorted
        highScores = highScores.OrderBy(entry => -entry.score).ToList();

        //I needed to add a check for the date here, but i ran out of time

        //In case High scores list has extra entries
        if (highScores.Count > 10)
        {
            highScores = highScores.GetRange(0, 10);
        }

        return highScores;
    }

    public static void AddNewHighScore(int score, string name)
    {
        var HighScores = GetHighScores();
        HighScores.Add(new HighScoreEntry() { name = name, score = score, date = DateTime.Now });
        HighScores = FixHighScoreList(HighScores);
        SaveHighScores(HighScores);
    }

    public static void SaveHighScores(List<HighScoreEntry> highScoreList)
    {
        try
        {
            var highScoresString = JsonUtility.ToJson(new HighScores() { highScoresList = highScoreList });
            PlayerPrefs.SetString(HIGH_SCORES_KEY, highScoresString);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    public static bool CheckIfHighScore(int score)
    {
        var highSores = GetHighScores();

        if (highSores.Count < 10) return true;

        return score > highSores.Last().score;
    }
}


[Serializable]
public class HighScores
{
    public List<HighScoreEntry> highScoresList;
}

[Serializable]
public class HighScoreEntry
{  
    public string name;
    public DateTime date;
    public int score;
}
