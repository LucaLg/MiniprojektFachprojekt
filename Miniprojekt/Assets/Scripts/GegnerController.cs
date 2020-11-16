using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
public class GegnerController : MonoBehaviour
{
    public int maxHealth;
    public int health;
    //public HealthbarEnemie healthbar;
    public float speed;
    private Transform playerPos;
    //Loot
    public float lootProbability;
    public GameObject[] loot;
    public GameObject spieler;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int punkte;
    public Text punkteText;

    //A Star Pathfinding Variablen
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    public Transform target;
    //Blut Effekt
    public GameObject blut;
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Spieler").transform;
        punkteText = GameObject.Find("Punkte").GetComponent<Text>();
    }

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = maxHealth;
        //healthbar.SetHealth(health, maxHealth);
        //A Star
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, .5f);

        
    }
    void UpdatePath()
    {
        if (seeker.IsDone()) { 
        seeker.StartPath(rb.position, playerPos.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
        //1.Bewegung ohne Umgebung Interaktion
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
    private void FixedUpdate()
    {
        //A Star
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;

        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
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
        int neuePunkzahl = System.Int32.Parse(punkteText.text) + punkte;
        punkteText.text = System.Convert.ToString(neuePunkzahl);
        SpawnLoot();
        Instantiate(blut, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(blut);

    }
    //Zweite Bewegung ohne Pathfinding
   /* private void FixedUpdate()
    {
        moveEnemy(movement);
    }
   
    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2) transform.position + (direction * speed * Time.deltaTime));
    }*/
    void SpawnLoot()
    {
        float randomizer = UnityEngine.Random.Range(0f, 1f);
        
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
    public int getHealth()
    {
        return health;
    }
}
