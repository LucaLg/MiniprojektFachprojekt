using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    
    //Lade Szene nach Position der Tuer 0=Unten , 1=Links ,2=Rechts , 3=Oben
    public string position;
    public string szenenName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Spieler")
        {
            GameObject player = GameObject.Find("Player");
            player.GetComponent<PlayerController>().spawnPosition = position;
            GameObject ui = GameObject.Find("PlayerUIGameObject");
            Camera cam = Camera.main;
           
                DontDestroyOnLoad(player);
                DontDestroyOnLoad(ui);
                DontDestroyOnLoad(cam);
            

            SceneManager.LoadScene(szenenName, LoadSceneMode.Single);
        }
    }
   
}
