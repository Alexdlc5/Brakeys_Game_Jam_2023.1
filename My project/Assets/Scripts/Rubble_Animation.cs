using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble_Animation : MonoBehaviour
{
    public AudioSource audio;
    public bool audio_played = false;
    public float animation_time = 12 / 60;
    Animator animator;
    bool stopped = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped && gameObject.activeSelf)
        {
            if (!audio_played)
            {
                audio_played = true;
                audio.Play();
            }
            if (animation_time > 0)
            {
                animation_time -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("Stop", true);
                stopped = true;
            }
        }
    }
}
