using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text scoretext;
    public int scorevalue;
    void Start()
    {
        scoretext = GetComponent<Text>();
        scorevalue = 0;
    }

    
    void Update()
    {
        scoretext.text = "Score: " + scorevalue;
    }
}
