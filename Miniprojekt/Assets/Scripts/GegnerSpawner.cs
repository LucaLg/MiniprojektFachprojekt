using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class GegnerSpawner : MonoBehaviour
{
    public GameObject enemySchnell;
    public GameObject enemyStandard;
    public int xPos, yPos;
    public float spawnRate = 2f;
    float nextSpawn;
    public int GegnerAnzahl;
    public Tilemap wand;
    public Tile tile;
    public GameObject door;
    public Tilemap umgebung;
    private bool standard=true;
    void Update()
    {
        if(GegnerAnzahl <= 10)
        {
            spawnRate = 0.5f;
        }
        if (GegnerAnzahl > 0 && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            xPos = System.Convert.ToInt32(Random.Range(-20f, 4f));
            yPos = System.Convert.ToInt32(Random.Range(-8f, 10f));
            TileBase spawnTile = umgebung.GetTile(new Vector3Int(xPos, yPos, 0));
             while(spawnTile != null) {
                xPos = Reroll(-20f,4f);
                yPos = Reroll(-8f,10f);
                spawnTile = umgebung.GetTile(new Vector3Int(xPos, yPos, 0));
            }
            if (standard)
            {
                Instantiate(enemyStandard, new Vector2(xPos, yPos), Quaternion.identity);
            }
            else
            {
                Instantiate(enemySchnell, new Vector2(xPos, yPos), Quaternion.identity);
            }
            standard = !standard;
            GegnerAnzahl = GegnerAnzahl - 1;

        }
        else if (GegnerAnzahl==0)
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
    int Reroll(float range1,float range2)
    {
        return System.Convert.ToInt32(Random.Range(range1,range2));
    }
}
