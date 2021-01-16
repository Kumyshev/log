using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Rotation : MonoBehaviour
{
    [SerializeField]
    private GameObject log;

    [SerializeField]
    private float logSpeed = 100;
    private WheelJoint2D logWheel;
    private JointMotor2D logMotor;
    [HideInInspector]
    public int point;

    private Level_Manager level_manager;

    private Log_Ps ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<Log_Ps>();
        level_manager = FindObjectOfType<Level_Manager>();
        logWheel = GetComponent<WheelJoint2D>();
        logMotor = new JointMotor2D();
    }

    // Update is called once per frame
    void Update()
    {
        logMotor.motorSpeed = logSpeed;
        logMotor.maxMotorTorque = 1000;
        logWheel.motor = logMotor;

        if (point == level_manager.lvl_knife_count[level_manager.lvl]) 
        {
            level_manager.all_points += point;

            if (level_manager.all_points > PlayerPrefs.GetInt("point")) 
            {
                PlayerPrefs.SetInt("point", level_manager.all_points);
            }

            level_manager.lvl++;

            level_manager.NewStart();


            Destroy(gameObject);

            ps.Action();

            
            
            Handheld.Vibrate();
        }
    }

    


}
