using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public int munition;
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
    //MuzzleFlash
    public ParticleSystem flash;
    //Schuss Animation
    public Animator schussAnim;
    //Waffen Sprite wechssel
    public Sprite shotgunSprite;
    public SpriteRenderer waffenSprite;
    public Sprite standartSprite;
    //3.Waffe Rapid Fire
    private bool waffe3 = false;
    // Update is called once per frame
    public Text munitionText;
    private void Awake()
    {
        cam = Camera.main;
    }
    void Update()
    {
        munitionText.text = munition.ToString();
        //Herz Update
        if(leben <= 0)
        {
            Die();
        }
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
            if (munition>0) { 
                Fire();
                munition--;
            }

        }
        
    }
    private void FixedUpdate()
    {
        //Bewegung aktuelle Position + Vector wo wir hin wollen * Geschwindigkeit des Characters
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        schussAnim.SetBool("Schuss", false);

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
            Bullet.flugzeit = 0.8f;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();   
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
             erzeugeMuzzleFlash();
            schussAnim.SetBool("Schuss", true);
        }
        else
        { 
            
            //Oben
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet.flugzeit = 0.2f;
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
            erzeugeMuzzleFlash();
            schussAnim.SetBool("Schuss", true);

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
        if(target.tag == "Herz" && leben != 5)
        {
            leben++;
            Destroy(target.gameObject);
        }
        if(target.tag == "Shotgun")
        {
            
            StartCoroutine( waffenWechsel());
            Destroy(target.gameObject);
        }
        if(target.tag == "Munition")
        {
            munition += 20;
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
        waffenSprite.sprite = shotgunSprite;
        yield return new WaitForSeconds(5f);
        waffe1 = true;
        waffenSprite.sprite = standartSprite;
    }
    void Die()
    {
        DataController.SetPunkte(System.Convert.ToInt32(GameObject.Find("Punkte").GetComponent<Text>().text));
        UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScreen", LoadSceneMode.Single);
    }
    private void erzeugeMuzzleFlash()
    {
        flash.Emit(30);
    }
    
}
