using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dungeon_Manager : MonoBehaviour
{
    //gameplay
    public int level = 0;
    public bool exploring_stage = true;
    public bool game_over = false;
    public bool won = false;
    public float escape_timer = 30;
    public GameObject safe_zone;
    //UI
    public TextMeshProUGUI timer;
    public Button resume;
    public GameObject pause_menu;
    public GameObject win_screen;
    private void Start()
    {
        Time.timeScale = 1;
        resume.onClick.AddListener(pause_play);
        timer.text = "Objective: Find the treasure!";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_play();
        }
        //if player dies
        if (game_over && !won)
        {
            timer.text = "Objective: Failed";
        }
        //if player wins
        else if (game_over)
        {
            win_screen.SetActive(true);
            timer.text = "Objective: Complete";
            if (Player_Data.levels_unlocked < level)
            {
                Player_Data.levels_unlocked = level;
            }
        }
        //if time to escape runs out 
        if (!exploring_stage && escape_timer <= 0)
        {
            game_over = true;
            timer.text = "Objective: Failed";
        }
        //countdown
        else if (!exploring_stage && !game_over)
        {
            safe_zone.SetActive(true);
            escape_timer -= Time.deltaTime;
            timer.text = "Objective: Escape!   Time until collapse: " + (int)escape_timer;
        }
    }
    public void pause_play()
    {
        if (Time.timeScale == 0)
        {
            pause_menu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pause_menu.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
