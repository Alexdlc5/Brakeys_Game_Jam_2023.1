using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stay_Upright : MonoBehaviour
{
    float parent_speed;
    private void Start()
    {
        parent_speed = gameObject.transform.parent.transform.parent.gameObject.GetComponent<Spin>().spin_speed;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 euler_angles = gameObject.transform.rotation.eulerAngles;
        Quaternion new_rotation = Quaternion.Euler(new Vector3(euler_angles.x, euler_angles.y, euler_angles.z - parent_speed * Time.deltaTime));
        gameObject.transform.rotation = new_rotation;
    }
}
