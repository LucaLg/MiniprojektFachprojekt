using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GegnerSpawner : MonoBehaviour
{
    public GameObject enemy;
    public float xPos, yPos;
    public float spawnRate = 2f;
    float nextSpawn;
    public int normalGegnerAnzahl;
    public Tilemap wand;
    public Tile tile;
    public GameObject door;
    public Tilemap umgebung;
    void Update()
    {

        if (normalGegnerAnzahl > 0 && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            xPos = Random.Range(-20f, 4f);
            yPos = Random.Range(-8f, 10f);
            TileBase spawnTile = umgebung.GetTile(new Vector3Int(System.Convert.ToInt32(xPos), System.Convert.ToInt32(yPos), 0));
            Instantiate(enemy, new Vector2(xPos, yPos), Quaternion.identity);
            normalGegnerAnzahl = normalGegnerAnzahl-1;
        }
        else if (normalGegnerAnzahl==0)
        {
            //Spawn Door
            Vector3Int vec1 = new Vector3Int(-8, 12, 0);
            Vector3Int vec2 = new Vector3Int(-7, 12, 0);
            Vector3Int vec3 = new Vector3Int(-9, 12, 0);
            Vector3Int vec4 = new Vector3Int(-6, 12, 0);
            wand.SetTile(vec1, tile);
            wand.SetTile(vec2, tile);
            wand.SetTile(vec3, tile);
            wand.SetTile(vec4, tile);
            door.SetActive(true);
        }
    }
}
