using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lebensAnzeige : MonoBehaviour
{
    private Text lebensfeld;
    public GameObject bossGegner;
    private int leben;
    private int startLeben;
    private Quaternion iniRot;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot = new Vector3(rot.x, rot.y, rot.z +180);
        
        lebensfeld = this.GetComponent<Text>(); 
        if(bossGegner.tag == "BossGegner") { 
        leben = this.GetComponentInParent<BossController>().getLeben();
            iniRot = Quaternion.Euler(rot);
          
        }
        else if(bossGegner.tag == "Gegner"){
            leben = bossGegner.GetComponentInChildren<GegnerController>().getHealth();
            iniRot = transform.rotation;
        }
        startLeben = leben;
        lebensfeld.text = leben.ToString() + "/" + startLeben.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = iniRot;
        if (bossGegner.tag == "BossGegner")
        {
            leben = this.GetComponentInParent<BossController>().getLeben();
        }
        else
        {
            leben = bossGegner.GetComponentInChildren<GegnerController>().getHealth();
        }
        lebensfeld.text = leben.ToString() + "/" + startLeben.ToString();
        transform.position = new Vector2(bossGegner.transform.position.x,bossGegner.transform.position.y +1f);
    }
}
