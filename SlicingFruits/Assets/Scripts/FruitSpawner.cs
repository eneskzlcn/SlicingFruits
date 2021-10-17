using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay =1f;

    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while(true)
        {
            float delay = Random.Range(minDelay,maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0,spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            
            int spawningFruit = Random.Range(0,fruitPrefabs.Length);

            GameObject go = Instantiate(fruitPrefabs[spawningFruit],spawnPoint.position,spawnPoint.rotation);
            Destroy(go,5.0f);
        }
    }
}
