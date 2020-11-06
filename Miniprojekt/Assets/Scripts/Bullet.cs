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
        switch (other.gameObject.tag)
        {

            case "Wand":

                Destroy(gameObject);
                break;
            case "Gegner":
                //Enemys take Damage other.GameObject.GetComponent<MyEnemyScript>().TakeDamage();
                GameObject gegner = other.gameObject;
                float leben = gegner.GetComponent<GegnerContoller>().health -= 1;
                Destroy(gameObject);
                break;
        }

    }
   
}
