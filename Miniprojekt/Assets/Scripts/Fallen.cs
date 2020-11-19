using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Fallen : MonoBehaviour
{
    public bool isActive;
    private int fallenStatus;
    public Tilemap fallen;
    public Animator fallenAnimator;
    private float timerCountDown = 2f;
    private bool isColliding = false;
    private bool healthLost = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding)
        {
            timerCountDown -= Time.deltaTime;
            if (timerCountDown < 0)
            {
                timerCountDown = 0;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spieler")
        {
            Debug.Log("Player Entered");
            
            isColliding = true;
            
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spieler" && isColliding)
        {
            fallenAnimator.SetBool("drauf",true);
            Debug.Log("Countdown not done yet");
            if (timerCountDown <= 0 && !healthLost)
            {
                
                collision.gameObject.GetComponent<PlayerController>().leben--;
                healthLost = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spieler")
        {
            
            Debug.Log("Player Exited");
            fallenAnimator.SetBool("drauf", false);
            isColliding = false;
            healthLost = false;
            timerCountDown = 2f;

        }
    }


}
