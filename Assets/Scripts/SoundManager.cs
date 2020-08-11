using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject SoundParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            SwitchSounds();
    }

    public void SwitchSounds() {
        for (var i = 0; i < SoundParent.transform.childCount; i++)
        {
            var aSource = SoundParent.transform.GetChild(i).GetComponent<AudioSource>();

            if (aSource)
                aSource.enabled = !aSource.enabled;
        }
    }
}