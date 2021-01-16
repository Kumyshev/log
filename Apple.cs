using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem appleDestruction;

    private SpriteRenderer sp;

    private Collider2D cldr;

    [HideInInspector]
    public int coint;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        cldr = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Knife")) 
        {
            coint += 2;

            PlayerPrefs.SetInt("coint", coint += PlayerPrefs.GetInt("coint"));

            cldr.enabled = false;
            sp.enabled = false;

            appleDestruction.Play();
            Destroy(gameObject, 1f);
        }
    }
}
