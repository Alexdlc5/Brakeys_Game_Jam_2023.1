using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    public bool touching_ground = false;
    HashSet<GameObject> ground_objects = new HashSet<GameObject>();
    private void Update()
    {
        if (ground_objects.Count > 0)
        {
            touching_ground = true;
        }
        else
        {
            touching_ground = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ground_objects.Contains(collision.gameObject) && collision.gameObject.tag.Equals("Ground"))
        {
            ground_objects.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            ground_objects.Remove(collision.gameObject);
        }
    }
}
