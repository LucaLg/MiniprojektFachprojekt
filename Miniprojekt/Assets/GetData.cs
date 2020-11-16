using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public Text textPunkte, textZeit;
    void Start()
    {
        textPunkte.text = "Punkte: " + DataController.GetPunkte();
        textZeit.text = "Zeit: " + DataController.BerechneGesamtZeit();
    }
}
