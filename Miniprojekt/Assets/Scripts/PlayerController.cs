﻿using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;
    public Transform firePoint;
    public Transform firePointLinks;
    public Transform firePointRechts;
    //Waffen
    private bool waffe1 = true;
    private bool unverwundbar = false;
    private float unverwundbarZeit = 1f;
    public GameObject bulletPrefab;
    public float bulletForce;
    public int leben;
    public int anzahlHerzen;
    public Image[] herzen;
    public Sprite leeresHerz;
    public Sprite vollesHerz;
    Vector2 movement;
    Vector2 mousePos;
    // Update is called once per frame
    void Update()
    {
        //Herz Update
        if(leben > anzahlHerzen)
        {
            leben = anzahlHerzen;
        }
        for (int i = 0; i < herzen.Length; i++)
        {
            if (i < leben)
            {
                herzen[i].sprite = vollesHerz;
            }
            else
            {
                herzen[i].sprite = leeresHerz;
            }
            if (i < anzahlHerzen)
            {
                herzen[i].enabled = true;
            }
            else
            {
                herzen[i].enabled = false;
            }
        }
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
        if (waffe1) { 
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
        else
        { 
            //Oben
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            //Links
            GameObject bulletLinks = Instantiate(bulletPrefab, firePointLinks.position, firePointLinks.rotation);
            Rigidbody2D rb2 = bulletLinks.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePointLinks.up * bulletForce, ForceMode2D.Impulse);
            //Rechts
            GameObject bulletRechts = Instantiate(bulletPrefab, firePointRechts.position, firePointRechts.rotation);
            Rigidbody2D rb3 = bulletRechts.GetComponent<Rigidbody2D>();
            rb3.AddForce(firePointRechts.up * bulletForce, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Gegner") {
            if (!unverwundbar)
            {
                leben--;
                StartCoroutine(Unverwundbarkeit());
            }
            
        }
        if(target.tag == "Herz")
        {
            leben++;
            Destroy(target.gameObject);
        }
        if(target.tag == "Shotgun")
        {
            StartCoroutine( waffenWechsel());
            Destroy(target.gameObject);
        }
    }
    IEnumerator Unverwundbarkeit()
    {
        unverwundbar = true;
        yield return new WaitForSeconds(unverwundbarZeit);
        unverwundbar = false;
    }
    IEnumerator waffenWechsel()
    {
        waffe1 = false;
        yield return new WaitForSeconds(3f);
        waffe1 = true;
    }
    
}
