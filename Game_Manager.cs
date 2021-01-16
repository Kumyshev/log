using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{


    private int knifeCount;

    [SerializeField]
    private GameObject knifePref;

    [SerializeField]
    private GameObject logPref;


    [SerializeField]
    private GameObject log_knifePref;


    [SerializeField]
    private AppleProbability probability;

    [SerializeField]
    private Transform[] apple_transform;

    [SerializeField]
    private Transform[] knife_transform;

    private Vector3 knife_position = new Vector3(0, -3, 0);

    private Vector3 log_position = new Vector3(0, 2, 0);

    [HideInInspector]
    public bool castKnife = true;

    [HideInInspector]
    public bool hitState = true;




    public void Game(int lvl, int lvl_knife_count) 
    {
        knifeCount = lvl_knife_count;


        
        GameObject logObj = Instantiate(logPref, log_position, Quaternion.identity);

        if (probability.probability > Random.value)
        {
            int i = Random.Range(0, 1);
            GameObject apple = Instantiate(probability.prefab, apple_transform[i].position, apple_transform[i].rotation);
            apple.transform.SetParent(logObj.gameObject.transform.GetChild(0).transform);
        }

        if (lvl > 0) 
        {
            for (int i = 0; i < lvl; i++) 
            {
                GameObject knife = Instantiate(log_knifePref, knife_transform[i].position, knife_transform[i].rotation);
                knife.transform.SetParent(logObj.gameObject.transform.GetChild(0).transform);
            }
        }
        Cast();
    }


    public void Cast() 
    {
        if (knifeCount > 0)
        { 
            StartCoroutine(MoveRoutine());
        }
    }

    private IEnumerator MoveRoutine()
    {
        yield return new WaitForSeconds(1);
        Instantiate(knifePref, knife_position, Quaternion.identity);
        knifeCount--;
    }


}
