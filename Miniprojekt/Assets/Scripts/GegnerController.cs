using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GegnerController : MonoBehaviour
{
    public float maxHealth;
    public float health;
    //public HealthbarEnemie healthbar;
    public float speed;
    private Transform playerPos;
    //Loot
    public float lootProbability;
    public GameObject[] loot;
    public GameObject spieler;
    private Rigidbody2D rb;
    private Vector2 movement;
   
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Spieler").transform;
        
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = maxHealth;
        //healthbar.SetHealth(health, maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        /*if (Vector2.Distance(transform.position, playerPos.position) > 1.5f)
        {
            //Bewegung
            // transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            transform.LookAt(playerPos);
            gameObject.GetComponent<Rigidbody2D>().AddForce(playerPos.position * speed , ForceMode2D.Impulse);
        }
        RotateTowards(playerPos.position);*/
        Vector3 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        if (health <= 0)
        {
            Die();
        }
    }
    private void RotateTowards(Vector2 target)
    {
        var offset = -90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

    void Die()
    {
        
        SpawnLoot();
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        moveEnemy(movement);
    }
    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2) transform.position + (direction * speed * Time.deltaTime));
    }
    void SpawnLoot()
    {
        float randomizer = Random.Range(0f, 1f);
        
        if(randomizer <= lootProbability)
        {
             if(randomizer < 0.7*lootProbability)
            { 
                Instantiate(loot[0], transform.position, Quaternion.identity); 
            }
            else if(randomizer >= 0.7 * lootProbability)
            {
                Instantiate(loot[1], transform.position, Quaternion.identity);
            }
            
            
        }
    }
    
}
