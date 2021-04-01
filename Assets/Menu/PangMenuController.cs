using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PangMenuController : PangMenuElement
{
    public void StartGame()
    {
        SceneManager.LoadScene(App.Model.StartScene);
    }

    public void CloseHighScores()
    {
        App.View.HighScores.gameObject.SetActive(false);
    }

    public void ShowHighScoreView()
    {
        App.View.HighScores.gameObject.SetActive(true);

        //performance-wise it is better to not destroy and instantiate again, 
        //but I think that this way the code is kept more maintainable
        //and 10 Instantiate are not that performance heavy

        foreach (Transform entry in App.View.HighScores.EntryParent)
        {
            Destroy(entry.gameObject);
        }

        App.Model.HighScores.ForEach(AddHighScoreEntry);
    }

    private void AddHighScoreEntry(HighScoreEntry entry)
    {
        var entryViewGO = Instantiate(App.Model.HighScoreEntryPrefab, App.View.HighScores.EntryParent);
        var entryView = entryViewGO.GetComponent<HighScoreEntryView>();
        if (entryView == null)
        {
            Debug.LogError("Error building HighScore window");
            Application.Quit();
        }

        entryView.SetData(entry);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
