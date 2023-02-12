using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dungeon_Manager : MonoBehaviour
{
    //gameplay
    public bool exploring_stage = true;
    public bool game_over = false;
    public bool won = false;
    public float escape_timer = 30;
    public GameObject safe_zone;
    //UI
    public TextMeshProUGUI timer;
    private void Start()
    {
        timer.text = "Objective: Find the treasure!";
    }
    // Update is called once per frame
    void Update()
    {
        //if player dies
        if (game_over && !won)
        {
            timer.text = "Objective: Failed";
        }
        else if (game_over)
        {
            timer.text = "Objective: Complete";
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
}
