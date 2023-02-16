using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    public Ground_Check[] Left_and_Right;
    public float respawn_delay = 1;
    public float health = 10;
    public float speed = 1;
    public float jump_power = 1;
    public Ground_Check groundCollider;
    public Rigidbody2D rb;
    public Dungeon_Manager dm;
    public Animator animator;
    public ParticleSystem blood;
    private BoxCollider2D collider2D;
    private bool R = false;
    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        blood.Pause();
    }
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            animator.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            blood.Play();
            dm.game_over = true;
            if (respawn_delay > 0)
            {
                respawn_delay -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(dm.level + 2);
            }
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
        if (Left_and_Right[0].touching_ground || Left_and_Right[1].touching_ground)
        {
            animator.SetInteger("Action", 2);
        }
    }
    private void FixedUpdate()
    {
        //set defaults 
        collider2D.size = new Vector2(collider2D.size.x, 1.512317f);
        collider2D.offset = new Vector2(collider2D.offset.x, -0.05671078f);
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
            collider2D.size = new Vector2(collider2D.size.x, 1.179658f);
            collider2D.offset = new Vector2(collider2D.offset.x, 0.1096186f);
        } 
        animator.SetBool("R", R);
        if (Left_and_Right[0].touching_ground || Left_and_Right[1].touching_ground)
        {
            animator.SetInteger("Action", 4);
        }
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

