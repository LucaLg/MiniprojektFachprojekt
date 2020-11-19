using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public float bossSpeed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    private float timeBetweenShoots;
    public float startTimeBtShoots;
    public GameObject gegnerBullet;
    public int leben;
    private Rigidbody2D rb;
    public float xBoundLeft;
    public float xBoundRight;
    private bool moveRight;
    // Punkte
    private Text punkteText;
    // Start is called before the first frame update
    private void Awake()
    {
        punkteText = GameObject.Find("Punkte").GetComponent<Text>();
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Spieler").transform;
        timeBetweenShoots = startTimeBtShoots;
    }

    // Update is called once per frame
    void Update()
    {
        //Leben
        if (leben <= 0)
        {
            Die();
        }
        this.GetComponent<Animator>().ResetTrigger("Attack");
        //Rotation
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        
        //Neue Bewegung Geh rechts nach Links ab Movment Phase 1 und 3
        if(leben > 35 || leben < 20) { 
            Vector3 xBoundsRight = new Vector3(xBoundRight, 10, 0);
            Vector3 xBoundsLeft = new Vector3(xBoundLeft, 10, 0);
            if (transform.position.x <= xBoundLeft )
            {
                moveRight = true;
            
            }
            if(transform.position.x >= xBoundRight)
            {
                moveRight = false;
            }
            if (moveRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, xBoundsRight, bossSpeed * Time.deltaTime);
            }else if (!moveRight)
            {
                transform.position = Vector2.MoveTowards(transform.position, xBoundsLeft, bossSpeed * Time.deltaTime);
            }
        }
        //Movement Phase 2
        //Bewegung Alt
        if(leben <=35 && leben >= 20) { 
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, bossSpeed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -bossSpeed * Time.deltaTime);
            }
        }
        //Schiessen Phase1;
        if (leben >= 35) { 
            if(timeBetweenShoots <= 0)
            {
                this.GetComponent<Animator>().SetTrigger("Attack");
                Instantiate(gegnerBullet, transform.position, Quaternion.identity);
                
                timeBetweenShoots = startTimeBtShoots;
            }
            else
            {
                timeBetweenShoots -= Time.deltaTime;
            }
        }
        else if (leben >= 20) //Phase 2
        {
            startTimeBtShoots = 0.7f;
            bossSpeed = 8f;
            if (timeBetweenShoots <= 0)
            {
                this.GetComponent<Animator>().SetTrigger("Attack");
                Instantiate(gegnerBullet, transform.position, Quaternion.identity);
                gegnerBullet.GetComponent<BossBullet>().speed = 60;
                timeBetweenShoots = startTimeBtShoots;
            }
            else
            {
                timeBetweenShoots -= Time.deltaTime;
            }
        }
        else //Phase 3
        {
            startTimeBtShoots = 0.3f;
            bossSpeed = 10f;
            if (timeBetweenShoots <= 0)
            {
                this.GetComponent<Animator>().SetTrigger("Attack");
                Instantiate(gegnerBullet, transform.position, Quaternion.identity);
               
                timeBetweenShoots = startTimeBtShoots;
            }
            else
            {
                timeBetweenShoots -= Time.deltaTime;
            }
        }
        
    }
    void Die()
    {
        int neuePunkzahl = System.Int32.Parse(punkteText.text) + 100;
        punkteText.text = System.Convert.ToString(neuePunkzahl);
        Destroy(gameObject);
        SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
    }
    public int getLeben()
    {
        return leben;
    }
}
