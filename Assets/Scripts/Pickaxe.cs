using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Pickaxe : MonoBehaviour
{
    public float AttackRadius;
    public Statistics Statistics;
    public LayerMask TargetLayer;
    public Animator Animator;

    [Space]

    public int MaxHitCountForGold;
    public int HitCountForGold;
    public int GoldGain;

    [Space]

    public AudioSource GoldCollect;
    public AudioSource MineGrind;
    public AudioSource PickaxeMiss;

    [Space]

    public GameObject Pointer;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        var hit = Physics2D.OverlapCircle(transform.position, AttackRadius, TargetLayer);

        if (hit != null)
        {
            var goldMine = hit.GetComponent<GoldMine>();

            if (goldMine != null)
            {
                if (Pointer.activeSelf)
                    Pointer.gameObject.SetActive(false);

                goldMine.CreateHitParticle();

                HitCountForGold++;

                if (HitCountForGold == MaxHitCountForGold)
                {
                    Statistics.Gold += GoldGain;
                    HitCountForGold = 0;

                    TextSpawner.Instance.SpawnText("+" + GoldGain + " gold!", 20.0f, Color.yellow, goldMine.transform.position,
                        new Vector3(0.0f, 20.0f, 0.0f));

                    GoldCollect.Play();
                }
                else
                {
                    TextSpawner.Instance.SpawnText("x" + HitCountForGold.ToString(), 20.0f, Color.black, goldMine.transform.position,
                        new Vector3(0.0f, 20.0f, 0.0f));

                    MineGrind.Play();
                }
            }
        }
        else
        {
            PickaxeMiss.Play();
        }

        TriggerSwingAnimation();
    }

    private void TriggerSwingAnimation()
    {
        Animator.SetTrigger("Swing");
    }
}