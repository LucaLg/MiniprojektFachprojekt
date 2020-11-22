using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntferneDuplikate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Duplikate Loeschen Spieler
        int anzahl = GameObject.FindGameObjectsWithTag("Spieler").Length;
        Debug.Log(anzahl.ToString());
        if (anzahl == 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Spieler")[0]);
        }
        //Duplikate Loeschen Camera
        int anzahlCamera = GameObject.FindGameObjectsWithTag("MainCamera").Length;
        Debug.Log(anzahl.ToString());
        if (anzahlCamera > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("MainCamera")[0]);
        }
        //Duplikate Loeschen UI
        int anzahlUI = GameObject.FindGameObjectsWithTag("SpielerUI").Length;
        Debug.Log(anzahl.ToString());
        if (anzahlUI == 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("SpielerUI")[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
