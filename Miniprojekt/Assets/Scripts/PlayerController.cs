using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;
    public Transform firePoint;
    
    public GameObject bulletPrefab;
    public float bulletForce;
    public int health;
    Vector2 movement;
    Vector2 mousePos;
    // Update is called once per frame
    void Update()
    {
        //Movement Vector zwischen speichern
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // Mouse Position zum Zielen zwischenspeichern
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    private void FixedUpdate()
    {
        //Bewegung aktuelle Position + Vector wo wir hin wollen * Geschwindigkeit des Characters
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
       
        /*
         * Maus Position - aktuelle Position = Vector von Spieler zur Maus Position
         * Z Roatation Winkel um Character zu drehen Mathf Rad2Deg um Grad der Drehung zu bekommen
         * */
        Vector2 lookDir = mousePos - rb.position;
        float zRotation = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = zRotation;   
    }
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Gegner") {
            health--;
        }
    }
}
