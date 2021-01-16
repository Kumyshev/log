using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifesUI : MonoBehaviour
{
    [SerializeField]
    private GameObject knife_icon;

    private List<GameObject> icons = new List<GameObject>();

    [SerializeField]
    private Color active_knife;

    [SerializeField]
    private Color passive_knife;

    private int itr;

    public void DeleteIcon() 
    {

        itr = icons.Count;

        if (itr != 0)
        {
            for (int i = 0; i < itr; i++)
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }
        }
    }

    public void Set_Knife(int number) 
    {
        icons.Clear();

        for (int i = 0; i < number; i++) 
        {
            GameObject icon = Instantiate(knife_icon, transform);
            icon.GetComponent<Image>().color = active_knife;
            icons.Add(icon);
        }
    }

    public void Get_Knife(int number) 
    {
        if (number < icons.Count)
        {
            icons[number].GetComponent<Image>().color = passive_knife;
        }
    }
}
