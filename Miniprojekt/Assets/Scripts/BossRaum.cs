using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRaum : MonoBehaviour
{
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(boss, new Vector2(-6, 9), Quaternion.Inverse(Quaternion.identity));
        GameObject player = GameObject.FindGameObjectWithTag("Spieler");
        Vector3 playerPos = new Vector3(-6, -9, 0);
        player.transform.position = playerPos;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
