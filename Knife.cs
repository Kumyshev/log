using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{


    [SerializeField]
    private Vector2 castForce;


    private Rigidbody2D rb;
    private BoxCollider2D cldr;

    private bool hitLog = false;
    

    private Game_Manager game;

    private Log_Rotation log;

    private Progress_Control control;

    private KnifesUI knifesUI;

    private Level_Manager level;

    void Start()
    {
        level = FindObjectOfType<Level_Manager>();
        knifesUI = FindObjectOfType<KnifesUI>();
        control = FindObjectOfType<Progress_Control>();
        log = FindObjectOfType<Log_Rotation>();
        game = FindObjectOfType<Game_Manager>();
        rb = GetComponent<Rigidbody2D>();
        cldr = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !hitLog)
        {
            rb.AddForce(castForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            game.Cast();
        }
    }


    public void Throw() 
    {

        knifesUI.Get_Knife(level.counter);
        level.counter++;

        rb.AddForce(castForce, ForceMode2D.Impulse);
        rb.gravityScale = 1;
        game.Cast();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (hitLog)
            return;

        hitLog = true;

        if (collision.gameObject.CompareTag("Log")) 
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            transform.SetParent(collision.collider.transform);
            cldr.offset = new Vector2(cldr.offset.x, -0.4f);
            cldr.size = new Vector2(cldr.size.x, 1.2f);
            ++log.point;
            control.GetPoint();
            Handheld.Vibrate();

            int num = 0;
            foreach (var max in level.lvl_knife_count) 
            {
                if (max > num) 
                {
                    num = max;
                }
                
            }
            if (log.point == num) 
            {
                level.WinPanel();
            }
        }

        else if (collision.gameObject.CompareTag("Knife"))
        {
            rb.velocity = new Vector2(rb.velocity.x, -2);
            SceneManager.LoadScene("Game");
            Handheld.Vibrate();
        }
    }

}

