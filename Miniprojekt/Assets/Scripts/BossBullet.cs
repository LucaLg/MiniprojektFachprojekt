using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private Transform player;
    private Vector2 target;
    private Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Spieler").transform;
        target = new Vector2(player.position.x, player.position.y);
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spieler")
        {
            
            Destroy(gameObject);
        }

    }
    
}
