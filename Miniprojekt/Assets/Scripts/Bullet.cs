using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Collider2D other = collision.collider;
        if(other.gameObject.tag == "Wand")
        {
            Destroy(gameObject);
        }
        //switch (other.gameObject.tag)
        //{
            

        //    case "Wand":

        //        Destroy(gameObject);
        //        break;
            //case "Gegner":
            //    //Enemys take Damage other.GameObject.GetComponent<MyEnemyScript>().TakeDamage();
            //    GameObject gegner = other.gameObject;
            //    gegner.GetComponent<GegnerController>().health -= 1;
            //    Destroy(gameObject);
            //    break;
        //}

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Gegner")
        {
            other.gameObject.GetComponent<GegnerController>().health -= 1;
            Destroy(gameObject);
        }
    }
   
}
