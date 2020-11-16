using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighscores : MonoBehaviour
{
    public Text textErster, textZweiter, textDritter;
    void Start()
    {
        textErster.text = "1. " + PlayerPrefs.GetString("HighscoreErsterName", "-") + "\t" + System.Convert.ToString(PlayerPrefs.GetInt("HighscoreErsterPunkte", 0));
        textZweiter.text = "2. " + PlayerPrefs.GetString("HighscoreZweiterName", "-") + "\t" + System.Convert.ToString(PlayerPrefs.GetInt("HighscoreZweiterPunkte", 0));
        textDritter.text = "3. " + PlayerPrefs.GetString("HighscoreDritterName", "-") + "\t" + System.Convert.ToString(PlayerPrefs.GetInt("HighscoreDritterPunkte", 0));
    }
}
