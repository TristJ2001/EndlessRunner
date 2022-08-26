using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using SimpleJSON;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FetchDatabaseData : MonoBehaviour
{
    public delegate void PlayerDataFetchedAction(List<PlayerData> players);
    public static event PlayerDataFetchedAction OnPlayerDataFetched;
    
    [SerializeField] private string BaseURL;

    public static FetchDatabaseData _instance;

    public void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
    }

    public void Start()
    {
        FetchPlayerData();
    }
    public void FetchPlayerData()
    {
        StartCoroutine(FetchData("PlayerData"));
    }
    
    private IEnumerator FetchData(string collectionName)
    {
        UnityWebRequest www = UnityWebRequest.Get(BaseURL + collectionName + ".json");

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Download complete!");
            Debug.Log(www.downloadHandler.text);

            ProcessPlayerData(www.downloadHandler.text);

            www.Dispose();
        }
    }
    
    void ProcessPlayerData(string json)
    {
        JSONNode rootNode = JSON.Parse(json);
        List<PlayerData> players = new List<PlayerData>();

        foreach (JSONNode entry in rootNode)
        {
            string name = entry["name"];
            int score = entry["score"];
            int level = entry["level"];

            PlayerData data = new PlayerData(score, name, level);
            players.Add(data);
        }
        
        OnPlayerDataFetched?.Invoke(players);
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
