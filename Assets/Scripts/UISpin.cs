using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISpin : MonoBehaviour
{
    public float SpinSpeed;
    public bool Direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Direction)
            transform.Rotate(Vector3.forward * SpinSpeed * Time.deltaTime);
        else
            transform.Rotate(Vector3.back * SpinSpeed * Time.deltaTime);
    }
}
