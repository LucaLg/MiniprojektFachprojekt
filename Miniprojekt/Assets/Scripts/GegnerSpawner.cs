using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerSpawner : MonoBehaviour
{
    public GameObject enemy;
    public float xPos, yPos;
    public float spawnRate = 2f;
    float nextSpawn;
    public int normalGegnerAnzahl;
    public GameObject boss;
    private int bossanzahl;
    private void Start()
    {
        bossanzahl = 0;
      
    }
    void Update()
    {

        if (normalGegnerAnzahl > 0 && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            xPos = Random.Range(-20f, 6f);
            yPos = Random.Range(-7f, 13f);
            Instantiate(enemy, new Vector2(xPos, yPos), Quaternion.identity);
            normalGegnerAnzahl = normalGegnerAnzahl-1;
        }
        else if (normalGegnerAnzahl==0 && bossanzahl == 0)
        {
            Instantiate(boss, new Vector2(-8.25f, 2), Quaternion.identity);
            bossanzahl = 1;
        }
    }
}
