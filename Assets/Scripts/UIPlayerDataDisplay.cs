using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIPlayerDataDisplay : MonoBehaviour
{
    [SerializeField] private GameObject playerDataEntryPrefab;

    private List<GameObject> playerDataEntryPrefabs = new List<GameObject>();

    private List<GameObject> sortedPLayerDataEntryPrefabs = new List<GameObject>();
    
    void Start()
    {
        FetchDatabaseData._instance.FetchPlayerData();
    }

    private void OnEnable()
    {
        FetchDatabaseData.OnPlayerDataFetched += OnPlayerDataFetched;
    }

    private void OnDisable()
    {
        FetchDatabaseData.OnPlayerDataFetched -= OnPlayerDataFetched;
    }

    void OnPlayerDataFetched(List<PlayerData> players)
    {
        foreach (GameObject prefab in playerDataEntryPrefabs)
        {
            Destroy(prefab);
        }
        playerDataEntryPrefabs.Clear();
        
        foreach (PlayerData data in players)
        {
            GameObject playerDataEntryGO = Instantiate(playerDataEntryPrefab, transform);
            UIPlayerDataEntry entry = playerDataEntryGO.GetComponent<UIPlayerDataEntry>();
            entry.SetName(data.name);
            entry.SetScore(data.score);
            entry.SetLevel(data.level);
            
            playerDataEntryPrefabs.Add(playerDataEntryGO);
        }
    }
}

