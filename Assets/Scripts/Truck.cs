using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public int MinGoldToAccept;
    public int GemPerAcceptedGold;
    public AudioSource TruckDeploy;
    public AudioSource TruckDeployFail;

    public bool HasCollidedWithPlayer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !HasCollidedWithPlayer)
        {
            var statistics = collision.GetComponent<Statistics>();

            if (statistics != null)
            {
                if (statistics.Gold >= MinGoldToAccept)
                {
                    var count = statistics.Gold / MinGoldToAccept;
                    var totalGoldLost = 0;
                    var totalGemEarned = 0;

                    for (var i = 0; i < count; i++)
                    {
                        statistics.Gold -= MinGoldToAccept;
                        totalGoldLost += MinGoldToAccept;
                        statistics.Gem++;
                        totalGemEarned++;
                    }

                    TextSpawner.Instance.SpawnFadingTextLonger("-" + totalGoldLost.ToString() + " gold!", 25.0f, Color.red, Vector3.zero,
                        new Vector3(0.0f, 80.0f, 0.0f));

                    TextSpawner.Instance.SpawnFadingTextLonger("+" + totalGemEarned.ToString() + " gem!", 25.0f, Color.green, Vector3.zero,
                        new Vector3(0.0f, 50.0f, 0.0f));

                    TruckDeploy.Play();
                }
                else
                {
                    TextSpawner.Instance.SpawnFadingTextLonger("Truck accepts at least " + MinGoldToAccept + " gold for trade!", 25.0f, Color.red, Vector3.zero, Vector3.zero);
                    TruckDeployFail.Play();
                }
            }

            HasCollidedWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (HasCollidedWithPlayer)
            HasCollidedWithPlayer = false;
    }
}