using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Boss2Spawner : MonoBehaviour
{
    public delegate void OnBoss2Spawn();
    public static event OnBoss2Spawn OnBoss2SpawnActivated;
    
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform spawnpos;
    [SerializeField] private int spawnTime = 25;

    private SpawnPrefabs2 _spawnPrefabs2;
    private int i;
    
    private static bool isSpawned;
    public static bool IsSpawned
    {
        get { return isSpawned; }
        set { isSpawned = value; }
    }
    
    void Start()
    {
        _spawnPrefabs2 = GetComponent<SpawnPrefabs2>();
    }

    void FixedUpdate()
    {
        if (_spawnPrefabs2.numSpawned == spawnTime)
        {
            OnBoss2SpawnActivated?.Invoke();
            Spawner();
            spawnTime--;
        }
    }

    void Spawner()
    {
        isSpawned = true;
        GameObject boss2 = Instantiate(boss, spawnpos.transform.position, Quaternion.Euler(0, 90, 0));
    }
}