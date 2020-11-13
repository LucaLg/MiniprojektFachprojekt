using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerSpawner : MonoBehaviour
{
    public GameObject enemy;
    public float xPos, yPos;
    public float spawnRate = 2f;
    float nextSpawn;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            xPos = Random.Range(-20f, 6f);
            yPos = Random.Range(-7f, 13f);
            Instantiate(enemy, new Vector2(xPos, yPos), Quaternion.identity);

        }
    }
}
