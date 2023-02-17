using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public AudioSource sound;
    public bool dont_deactivate = false;
    public Animator animator;
    public bool pressure_anim_playing = false;
    public GameObject object_to_show;
    public bool damage_active = false;
    public float activation_time = 1;
    public float deactivation_time = 2;
    private bool activated = false;
    private float activation_timer = 0;
    private float deactivation_timer = 0;
    private void Update()
    {
        if (activated)
        {
            //activation timer
            if (!damage_active && activation_timer < activation_time)
            {
                activation_timer += Time.deltaTime;
            }
            else if (!damage_active) 
            {
                sound.Play();
                object_to_show.SetActive(true);
                activation_timer = 0;
                damage_active = true;
            }
            //deactivation timer 
            if (damage_active && !dont_deactivate)
            {
                if (deactivation_timer < deactivation_time)
                {
                    deactivation_timer += Time.deltaTime;
                }
                else
                {
                    object_to_show.SetActive(false);
                    deactivation_timer = 0;
                    damage_active = false;
                    activated = false;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            activated = true;
            animator.SetTrigger("Press");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            animator.SetTrigger("Release");
        }
    }
}
