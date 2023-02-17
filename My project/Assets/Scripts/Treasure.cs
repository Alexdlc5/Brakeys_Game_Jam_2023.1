using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public Dungeon_Manager dm;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && Input.GetKey(KeyCode.E))
        {
            dm.exploring_stage = false;
            GameObject.Find("Player").GetComponent<Player_Script>().pickup_sound.Play();
            Destroy(gameObject);
        }
    }
}
