using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    //Get Highscores - compare - save new Highscores
    void Start()
    {
        int punkte = DataController.GetPunkte();
        string name = DataController.GetSpielerName();
        if(punkte > PlayerPrefs.GetInt("HighscoreErsterPunkte" , 0)){
            PlayerPrefs.SetInt("HighscoreDritterPunkte", PlayerPrefs.GetInt("HighscoreZweiterPunkte", 0));
            PlayerPrefs.SetString("HighscoreDritterName", PlayerPrefs.GetString("HighscoreZweiterName", "-"));
            PlayerPrefs.SetInt("HighscoreZweiterPunkte", PlayerPrefs.GetInt("HighscoreErsterPunkte", 0));
            PlayerPrefs.SetString("HighscoreZweiterName", PlayerPrefs.GetString("HighscoreErsterName", "-"));
            PlayerPrefs.SetInt("HighscoreErsterPunkte", punkte);
            PlayerPrefs.SetString("HighscoreErsterName", name);
        }
        else if(punkte > PlayerPrefs.GetInt("HighscoreZweiterPunkte", 0))
        {
            PlayerPrefs.SetInt("HighscoreDritterPunkte", PlayerPrefs.GetInt("HighscoreZweiterPunkte", 0));
            PlayerPrefs.SetString("HighscoreDritterName", PlayerPrefs.GetString("HighscoreZweiterName", "-"));
            PlayerPrefs.SetInt("HighscoreZweiterPunkte", punkte);
            PlayerPrefs.SetString("HighscoreZweiterName", name);
        }
        else if(punkte > PlayerPrefs.GetInt("HighscoreDritterPunkte", 0))
        {
            PlayerPrefs.SetInt("HighscoreDritterPunkte", punkte);
            PlayerPrefs.SetString("HighscoreDritterName", name);
        }
    }
}
