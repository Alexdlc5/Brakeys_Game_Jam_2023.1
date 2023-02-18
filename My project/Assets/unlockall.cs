using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unlockall : MonoBehaviour
{
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(unlock);
    }

    void unlock()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
    }
}
