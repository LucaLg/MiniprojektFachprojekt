using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fallen : MonoBehaviour
{
    public bool isActive;
    private int fallenStatus;
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        fallenStatus = 1;
    }

    // Update is called once per frame
    void Update()
    {

        Color c=Color.white;
        if (fallenStatus == 1)
        {
            c = Color.yellow;
        }else if(fallenStatus == 2)
        {
            c = Color.red;
        }


        tilemap.SetTileFlags(new Vector3Int(-15, -6, 0), TileFlags.None);
        tilemap.SetColor(new Vector3Int(-15, -6, 0), Color.red);
        tilemap.RefreshAllTiles();

        //StartCoroutine(FallenStatus());

    }
    IEnumerator FallenStatus()
    {
        
        yield return new WaitForSeconds(3);
        if (fallenStatus <2)
        {
            fallenStatus++;
        }
        if(fallenStatus == 2)
        {
            fallenStatus = 0;
        }
    }
}
