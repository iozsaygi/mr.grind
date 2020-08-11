using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Statistics Statistics;
    public int GemCost;
    public TextMeshProUGUI CostText;
    public int NextUpgradeCostMultiplier;
    public Button UpgradeButton;
    public AudioSource PurchaseFailed;

    // Start is called before the first frame update
    void Start()
    {
        CostText.text = GemCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Activate()
    {

    }

    public void Purchase()
    {
        if (Statistics.Gem >= GemCost)
        {
            Statistics.Gem -= GemCost;
            GemCost *= NextUpgradeCostMultiplier;
            CostText.text = GemCost.ToString();

            Activate();
        }
        else
        {
            PurchaseFailed.Play();
        }
    }
}
