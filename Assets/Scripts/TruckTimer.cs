using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TruckTimer : MonoBehaviour
{
    public GameObject Truck;
    public int MaxSeconds;
    public int Seconds;
    public int MaxRandomTruckAssignment;
    public int MinRandomTruckAssignment;
    public float TruckWaitTime;

    public TextMeshProUGUI TruckMessage;
    public TextMeshProUGUI Timer;

    private string initialMessage;

    // Start is called before the first frame update
    void Start()
    {
        Timer.text = MaxSeconds.ToString();
        StartCoroutine(UpdateTimer());

        initialMessage = TruckMessage.text;
    }

    private IEnumerator UpdateTimer()
    {
        while (Seconds > 0)
        {
            yield return new WaitForSeconds(1.0f);

            Seconds--;

            Timer.text = Seconds.ToString();

            if (Seconds == 0)
            {
                var truckAnimator = Truck.GetComponent<Animator>();
                truckAnimator.SetBool("Enter", true);

                TruckMessage.text = "Go to the truck to sell the gold mine you've collected!";
                Timer.gameObject.SetActive(false);

                StartCoroutine(SendTruckBack());

                MaxSeconds = Random.Range(MinRandomTruckAssignment, MaxRandomTruckAssignment);
                Seconds = MaxSeconds;
            }
        }
    }

    private IEnumerator SendTruckBack()
    {
        yield return new WaitForSeconds(TruckWaitTime);

        var truckAnimator = Truck.GetComponent<Animator>();
        truckAnimator.SetBool("Enter", false);
        truckAnimator.SetTrigger("Exit");

        TruckMessage.text = initialMessage;
        Timer.gameObject.SetActive(true);
    }
}
