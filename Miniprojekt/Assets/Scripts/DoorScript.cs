using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public GameObject player;
    public GameObject bossGegner;
    public Canvas ui;
    public Camera cam;
    public Grid grid;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Spieler")
        {
            Scene bossRaum = SceneManager.GetSceneByName("BossRaum");
            Scene currentScene = SceneManager.GetSceneByName("SampleScene");
           /* Vector3 neuerPlayerPos = new Vector3(-4, 42, 0);
            player.transform.position = neuerPlayerPos;
            Camera.main.transform.position = new Vector3(-4, 50, -10);
            Instantiate(bossGegner, new Vector3(-4, 50, 0), Quaternion.identity);*/
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(ui);
            DontDestroyOnLoad(cam);
           // DontDestroyOnLoad(grid);
            SceneManager.LoadScene("BossRaum", LoadSceneMode.Single);
            
            

        }
    }
   
}
