using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPerSecondUpgrade : Upgrade
{
    public GameObject GoldPerSecondPrefab;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        var gps = FindObjectOfType<GoldPerSecond>();

        if (gps is null)
        {
            var go = Instantiate(GoldPerSecondPrefab, Vector3.zero, GoldPerSecondPrefab.transform.rotation);
            go.transform.SetParent(null);
        }
        else
        {
            gps.GPS++;
        }
    }
}
