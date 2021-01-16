using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{

    [SerializeField]
    private Game_Manager game_manager;

    [HideInInspector]
    public int lvl;

    public int[] lvl_knife_count;

    [HideInInspector]
    public int all_points;

    [SerializeField]
    private KnifesUI knifes;

    [HideInInspector]
    public int counter;


    [SerializeField]
    private GameObject win_panel;
    public void NewStart() 
    {
        StartCoroutine(Across_Time());
    }

    private IEnumerator Across_Time()
    {
        yield return new WaitForSeconds(2);
        NewLVL();
    }

    public void NewLVL() 
    {

        counter = 0;
        knifes.DeleteIcon();

        game_manager.Game(lvl, lvl_knife_count[lvl]);


        knifes.Set_Knife(lvl_knife_count[lvl]);
            
    }

    public void WinPanel()
    {
        StartCoroutine(WaitWinPanel());
    }

    private IEnumerator WaitWinPanel() 
    {
        yield return new WaitForSeconds(1);
        Time.timeScale = 0;
        win_panel.SetActive(true);
    }

    public void NewGame() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

}
