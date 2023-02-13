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
    public Animator animator;
    private bool R = false;
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
        } 
    }
    private void FixedUpdate()
    {
        animator.SetInteger("Action", 0);
        if (!dm.game_over)
        {
            if (Input.GetKey(KeyCode.A))
            {
                R = false;
                animator.SetInteger("Action", 1);
                transform.position -= (Vector3)Vector2.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                R = true;
                animator.SetInteger("Action", 1);
                transform.position += (Vector3)Vector2.right * speed * Time.deltaTime;
            }
        }
        if (!groundCollider.touching_ground)
        {
            animator.SetInteger("Action", 3);
        } 
        animator.SetBool("R", R);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Safe zone"))
        {
            dm.won = true;
            dm.game_over = true;
        }
        else if (collision.gameObject.tag.Equals("Kill"))
        {
            health = 0;
            Physics.gravity = Vector2.up * -3;
        }
        else if (collision.gameObject.tag.Equals("Damage"))
        {
            health -= 1;
        }
    }
}

