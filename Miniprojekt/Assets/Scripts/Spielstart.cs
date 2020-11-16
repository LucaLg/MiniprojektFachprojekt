using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spielstart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StarteSpiel()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
