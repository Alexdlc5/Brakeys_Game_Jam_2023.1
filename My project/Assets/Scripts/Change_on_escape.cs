using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Change_on_escape : MonoBehaviour
{
    public Dungeon_Manager dm;
    public string text;
    // Update is called once per frame
    void Update()
    {
        if (!dm.exploring_stage)
        {
            GetComponent<TextMeshPro>().text = text;
        }
    }
}
