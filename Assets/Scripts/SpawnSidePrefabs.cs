using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSidePrefabs : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform[] pos;

    void Start()
    {
        InvokeRepeating("Spawner1", 0f, 1f);
        InvokeRepeating("Spawner2", 0.5f, 1f);
    }

    void Spawner1()
    {
        int obstaclesIndex = Random.Range(0, obstacles.Length);

        GameObject clone = Instantiate(obstacles[obstaclesIndex], pos[0].transform.position,
            Quaternion.Euler(0, 90, 0));
    }
    
    void Spawner2()
    {
        int obstaclesIndex = Random.Range(0, obstacles.Length);
        
        GameObject clone = Instantiate(obstacles[obstaclesIndex], pos[1].transform.position,
            Quaternion.Euler(0, 90, 0));
    }
}
