using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public int score;
    public TMP_InputField TMP_IF;

    public void setScore(int xscore)
    {
        score = xscore;
    }

    public void getUserInput() {
        string username = TMP_IF.text;

        if (username != null) {
            username = username.ToString();
        }
        else
        {
            username = "user";
        }

        // create
        HighscoreEntry highscoreEntry = new HighscoreEntry {score = score, name = username};

        // load
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // add
        highscores.highscoreEntryList.Add(highscoreEntry);

        // sort
        highscores.highscoreEntryList.Sort((x, y) => y.score.CompareTo(x.score));

        // remove last
        int n = 10;
        if (highscores.highscoreEntryList.Count >= n)
        {
            highscores.highscoreEntryList.RemoveAt(n);
        }

        // save
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public void ToLeadeboard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MAIN MENU");
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
