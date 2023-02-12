using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public float health = 10;
    public float speed = 1;
    public float jump_power = 1;
    public Ground_Check groundCollider;
    public Rigidbody2D rb;
    public Dungeon_Manager dm;
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            dm.game_over = true;
        }
        if (!dm.game_over)
        {
            if (groundCollider.touching_ground)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(Vector2.up * jump_power);
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= (Vector3)Vector2.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += (Vector3)Vector2.right * speed * Time.deltaTime;
            }
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Safe zone"))
        {
            dm.won = true;
            dm.game_over = true;
        }  
    }
}

