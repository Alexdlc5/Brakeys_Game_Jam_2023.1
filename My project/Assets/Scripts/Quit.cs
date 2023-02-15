using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(quit);
    }
    private void quit()
    {
        Application.Quit();
    }
}
