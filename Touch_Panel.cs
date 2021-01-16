using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch_Panel : MonoBehaviour, IPointerClickHandler
{

    private Knife knife;


    public void OnPointerClick(PointerEventData pointerEventData)
    {
        try
        {
            knife = FindObjectOfType<Knife>();

            knife.Throw();
        }
        catch (Exception e)
        {

        }
        
    }
}
