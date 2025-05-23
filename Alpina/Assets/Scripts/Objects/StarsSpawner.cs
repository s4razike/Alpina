using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public float minX = -10f;
    public float maxX = 10f;
    public float spawnY = 10f; // Altura desde la que caen las estrellas

    public int starCount = 3;

    public float minDelay = 0.5f; // mínimo tiempo entre estrellas
    public float maxDelay = 2f;   // máximo tiempo entre estrellas

    void Start()
    {
        StartCoroutine(SpawnStarsRandomly());
    }

    IEnumerator SpawnStarsRandomly()
    {
        for (int i = 0; i < starCount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            Vector2 spawnPosition = new Vector2(randomX, spawnY);
            Instantiate(starPrefab, spawnPosition, Quaternion.identity);

            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }
}
