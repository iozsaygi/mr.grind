using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : Upgrade
{
    public Controller2D Controller2D;

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate()
    {
        Controller2D.Speed++;
    }
}
