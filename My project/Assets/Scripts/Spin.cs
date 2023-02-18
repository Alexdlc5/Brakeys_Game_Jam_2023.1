using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spin_speed = 10;
    // Update is called once per frame
    void Update()
    {
        Vector3 euler_angles = gameObject.transform.rotation.eulerAngles;
        Quaternion new_rotation = Quaternion.Euler(new Vector3(euler_angles.x, euler_angles.y, euler_angles.z + spin_speed * Time.deltaTime));
        gameObject.transform.rotation = new_rotation;
    }
}
