using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statistics : MonoBehaviour
{
    public int Gold;
    public int Gem;
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI GemText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = Gold.ToString();
        GemText.text = Gem.ToString();
    }
}