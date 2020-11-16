using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPunkte : MonoBehaviour
{
    public Text punkteFeld;
    void Start()
    {

        punkteFeld.text = "Score: " + System.Convert.ToString(DataController.GetPunkte());    
    }
}
