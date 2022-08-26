using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Boss1Spawner : MonoBehaviour
{
    public delegate void OnBossSpawn();
    public static event OnBossSpawn OnBoss1SpawnedAction;
    
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform spawnpos;
    [SerializeField] private int spawnTime = 25;

    private SpawnPrefabs _spawnPrefabs;
    private int i;
    
    private static bool isSpawned;
    public static bool IsSpawned
    {
        get { return isSpawned; }
        set { isSpawned = value; }
    }
    
    void Start()
    {
        _spawnPrefabs = GetComponent<SpawnPrefabs>();
    }

    void FixedUpdate()
    {
        if (_spawnPrefabs.numSpawned == spawnTime)
        {
            OnBoss1SpawnedAction?.Invoke();
            Spawner(); 
            spawnTime--;
        }
    }

    void Spawner()
    {
        isSpawned = true;
        GameObject boss1 = Instantiate(boss, spawnpos.transform.position, Quaternion.Euler(0, 90, 0));
    }
}
