using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public GameObject[] CloudPrefabs;
    public float MinY;
    public float MaxY;
    public float SpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateCloud());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private GameObject GetRandomCloud(Vector3 position)
    {
        var randIndex = Random.Range(0, CloudPrefabs.Length);
        return Instantiate(CloudPrefabs[randIndex], position, CloudPrefabs[randIndex].transform.rotation);
    }

    private IEnumerator GenerateCloud()
    {
        while (gameObject.activeSelf)
        {
            GetRandomCloud(new Vector2(transform.position.x, Random.Range(MinY, MaxY)));
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}
