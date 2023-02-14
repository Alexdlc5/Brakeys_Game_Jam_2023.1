using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Unlock_Manager : MonoBehaviour
{
    public GameObject[] level_buttons;
    // Start is called before the first frame update
    void Start()
    {
        int current_level_unlock = Player_Data.levels_unlocked;
        for (int i = 0; i <= current_level_unlock; i++)
        {
            level_buttons[i].SetActive(true);
        }
    }
}
