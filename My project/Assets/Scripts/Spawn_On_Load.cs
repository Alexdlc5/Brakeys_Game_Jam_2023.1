using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_On_Load : MonoBehaviour
{
    public GameObject prop;
    public Vector2 location;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prop, location, transform.rotation);
    }
}
