using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadingText : MonoBehaviour
{
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Modify( string msg, float fontSize, Color color )
    {
        Text.text = msg;
        Text.fontSize = fontSize;
        Text.color = color;
    }

    public void DestroyAnimEvent()
    {
        Destroy(this.gameObject);
    }

    public void PauseAnimEvent()
    {
        FindObjectOfType<TimeManager>().Pause();
    }
}
