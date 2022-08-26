using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SpawnPrefabs : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform[] pos;
    [SerializeField] private Transform fenceSpawnPos;
    [SerializeField] private int spawnSpeed;
    
    private int i;
    public int numSpawned;
    private bool stopSpawning;

    void Spawner1()
    {
        numSpawned++;
        int obstaclesIndex = Random.Range(0, obstacles.Length);
        int spawnPos = Random.Range(0, 2);

        if (obstaclesIndex == 0)
        {
            GameObject clone = Instantiate(obstacles[obstaclesIndex], fenceSpawnPos.transform.position,
                Quaternion.Euler(0, 90, 0));
        }
        else
        {
            GameObject clone = Instantiate(obstacles[obstaclesIndex], pos[spawnPos].transform.position,
                Quaternion.Euler(0, 90, 0));
        }

    }

    void FixedUpdate()
    {
        if (!stopSpawning)
        {
            if (i == spawnSpeed)
            {
                Spawner1();

                i = 0;
            }
            else
            {
                i++;
            }
        }
    }

    private void OnEnable()
    {
        Boss1Spawner.OnBoss1SpawnedAction += OnBoss1SpawnAction;
        B1ProjCont.OnBoss1DefeatedAction += OnBoss1DefeatedAction;
    }

    private void OnDisable()
    {
        Boss1Spawner.OnBoss1SpawnedAction -= OnBoss1SpawnAction;
        B1ProjCont.OnBoss1DefeatedAction -= OnBoss1DefeatedAction;
    }

    public void OnBoss1SpawnAction()
    {
        stopSpawning = true;
    }

    public void OnBoss1DefeatedAction()
    {
        stopSpawning = false;
    }
}
