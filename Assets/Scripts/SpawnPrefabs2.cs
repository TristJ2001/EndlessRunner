using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class SpawnPrefabs2 : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform[] pos;
    [SerializeField] private int spawnSpeed;
    [SerializeField] private GameObject piranhaPrefab;
    [SerializeField] private Transform piranhaSpawn;
    
    private int i;
    public int numSpawned;
    private bool stopSpawning;

    void Spawner1()
    {
        numSpawned++;
        int obstaclesIndex = Random.Range(0, obstacles.Length);
        int spawnPos = Random.Range(0, pos.Length);

        GameObject clone = Instantiate(obstacles[obstaclesIndex], pos[spawnPos].transform.position,
            Quaternion.Euler(0, 90, 0));
    }

    void PiranhaSpawner()
    {
        GameObject piranhaClone = Instantiate(piranhaPrefab, piranhaSpawn.transform.position,
            Quaternion.Euler(0, 90, 0));
    }
    void Awake()
    {
        InvokeRepeating("Spawner1", 0f, spawnSpeed);
        InvokeRepeating("PiranhaSpawner", 0f, 1f);
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
        Boss2Spawner.OnBoss2SpawnActivated += OnBoss2SpawnActivated;
        ShockwaveCont.OnBoss2DefeatedAction += OnBoss2DefeatedAction;
    }

    private void OnDisable()
    {
        Boss2Spawner.OnBoss2SpawnActivated -= OnBoss2SpawnActivated;
        ShockwaveCont.OnBoss2DefeatedAction -= OnBoss2DefeatedAction;
    }

    private void OnBoss2SpawnActivated()
    {
        stopSpawning = true;
    }

    private void OnBoss2DefeatedAction()
    {
        stopSpawning = false;
    }
}

