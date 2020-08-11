using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGainUpgrade : Upgrade
{
    public Pickaxe Pickaxe;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        Pickaxe.GoldGain++;
    }
}