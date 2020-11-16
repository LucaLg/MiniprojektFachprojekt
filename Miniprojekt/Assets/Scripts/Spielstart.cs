using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spielstart : MonoBehaviour
{
    public Text textName;
    public void StarteSpiel()
    {
        string name = textName.text;
        DataController.SetSpielerName(name);
        DataController.SetStartZeit(Time.time);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
