using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPerSecond : MonoBehaviour
{
    public int GPS = 1;
    public Statistics Statistics;
    public AudioSource AudioEffect;

    // Start is called before the first frame update
    void Start()
    {
        AudioEffect = GameObject.FindGameObjectWithTag("GoldCollect").GetComponent<AudioSource>();
        Statistics = FindObjectOfType<Statistics>();
        StartCoroutine(Execute());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Execute()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(1.0f);

            Statistics.Gold += GPS;

            TextSpawner.Instance.SpawnFadingTextLonger("GPS: +" + GPS.ToString() + " gold!", 20.0f, Color.yellow, Vector3.zero, Vector3.zero);

            AudioEffect.Play();
        }
    }
}
