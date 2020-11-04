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
                
                Destroy(gameObject);
                break;
        }

    }
   /* void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {

            case "Wand":
                
                Destroy(gameObject);
                break;
            case "Gegner":
                //Enemys take Damage other.GameObject.GetComponent<MyEnemyScript>().TakeDamage();
                GameObject enemy = other.gameObject;
                Destroy(enemy, 0.2f);
                Destroy(gameObject);
                break;
        }

    }*/
}
