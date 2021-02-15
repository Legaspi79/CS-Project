﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class LeaderboardTable : MonoBehaviour
{
    private Transform entryContainer;
    private static Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake() {
        entryContainer = GameObject.Find("highscoreEntryContainer").transform;
        entryTemplate = GameObject.Find("highscoreEntryTemplate").transform; // nullpointer bug

        entryTemplate.gameObject.SetActive(false);

        if (!PlayerPrefs.HasKey("highScoreTable")) {
            string path = Application.streamingAssetsPath + "/blankTable.txt";
            string njsonString = File.ReadAllText(path);
            PlayerPrefs.SetString("highScoreTable", njsonString);
        }

        /* highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry {score = 999, name = "AAA"},
            new HighscoreEntry {score = 888, name = "bbb"},
            new HighscoreEntry {score = 777, name = "ccc"},
            new HighscoreEntry {score = 666, name = "ddd"},
            new HighscoreEntry {score = 555, name = "eee"},
            new HighscoreEntry {score = 444, name = "fff"},
            new HighscoreEntry {score = 333, name = "ggg"},
            new HighscoreEntry {score = 222, name = "hhh"},
            new HighscoreEntry {score = 111, name = "iii"},
            new HighscoreEntry {score = 1000, name = "harambe"}
        }; */

        // load from json
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList){
        float templateHeight = 100f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = (transformList.Count + 1);
        int score = highscoreEntry.score;
        string name = highscoreEntry.name;

        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rank.ToString();
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name) {
        // create
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

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