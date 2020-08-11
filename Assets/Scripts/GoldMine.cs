using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    public GameObject HitParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateHitParticle()
    {
        var particle = Instantiate(HitParticle, transform.position, HitParticle.transform.rotation);
        Destroy(particle, 1.0f);
    }
}
