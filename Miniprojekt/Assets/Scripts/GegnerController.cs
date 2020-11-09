using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerController : MonoBehaviour
{
    public float health;
    public float speed;
    private Transform playerPos;
    //Loot
    public float lootProbability;
    public GameObject[] loot;
    
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Spieler").transform;
        
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > 1.5f)
        {
            //Bewegung
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
        RotateTowards(playerPos.position);

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
