using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReqUpgrade : Upgrade
{
    public Pickaxe Pickaxe;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        if (Pickaxe.MaxHitCountForGold > 1)
        {
            Pickaxe.MaxHitCountForGold--;
            Pickaxe.HitCountForGold = 0;
        }
    }
}