using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pickups;
    [SerializeField] private Transform[] pos;
    
    void Start()
    {
        InvokeRepeating("Spawner", 1.5f, 7f);
    }

    public  void Spawner()
    {
        int pickupIndex = Random.Range(0, pickups.Length);
        int rand = Random.Range(0, 3);
        GameObject clone = Instantiate(pickups[pickupIndex], pos[rand].transform.position, Quaternion.Euler(0,90,0));
    }
}
