using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress_Control : MonoBehaviour
{

    public Text curentPiont;

    public Text highScore;

    public Text highCoint;

    private Log_Rotation point;

    void Start()
    {
        
    }


    public void GetPoint() 
    {
        point = FindObjectOfType<Log_Rotation>();
        
        curentPiont.text = point.point.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        highScore.text = PlayerPrefs.GetInt("point").ToString();
        highCoint.text = PlayerPrefs.GetInt("coint").ToString();
    }
}
