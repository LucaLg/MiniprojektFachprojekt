using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Awake()
    {
        //Duplikate Loeschen Spieler
        int anzahl = GameObject.FindGameObjectsWithTag("Spieler").Length;
        Debug.Log(anzahl.ToString());
        if (anzahl > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Spieler")[1]);
        }
        //Duplikate Loeschen Camera
        int anzahlCamera = GameObject.FindGameObjectsWithTag("MainCamera").Length;
        Debug.Log(anzahl.ToString());
        if (anzahlCamera > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("MainCamera")[1]);
        }
        //Duplikate Loeschen UI
        int anzahlUI= GameObject.FindGameObjectsWithTag("SpielerUI").Length;
        Debug.Log(anzahl.ToString());
        if (anzahlUI > 1)
        {
            Destroy(GameObject.FindGameObjectsWithTag("SpielerUI")[1]);
        }
    }
    void Start()
    {
        Vector3 playerPos = new Vector3(-7, -4, 0);
        GameObject player = GameObject.FindGameObjectWithTag("Spieler");
        string position = player.GetComponent<PlayerController>().spawnPosition;
        if(position == "unten") { 
         playerPos = new Vector3(-7, -7, 0);
        }
        if (position == "links")
        {
             playerPos = new Vector3(-19, 1, 0);
        }
        if (position == "rechts")
        {
            playerPos = new Vector3(3, 1, 0);
        }
        if (position == "oben")
        {
             playerPos = new Vector3(-6, 11, 0);
        }
        player.transform.position = playerPos;
    }

}
