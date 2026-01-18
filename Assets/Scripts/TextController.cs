using UnityEngine;

public class TextController : MonoBehaviour
{
    // Volitelnì: Schová text na zaèátku hry
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ToogleText()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Debug.Log("Text toggled");
    }
}