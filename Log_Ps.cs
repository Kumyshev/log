using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Ps : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem logDestruction;

    public void Action() 
    {
        logDestruction.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
