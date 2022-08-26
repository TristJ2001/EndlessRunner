using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using SimpleJSON;
using UnityEngine.Events;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    [SerializeField] private string BaseURL;
    [SerializeField] private InputField InputText;
    [SerializeField] private Button button;
    public static DatabaseManager _instance;
    void Awake()
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
        button.onClick.AddListener(PostPlayerData);
    }
    
    public void AddPlayerData(PlayerData data)
    {
        StartCoroutine(PostData(data, "PlayerData"));
    }

    void PostPlayerData()
    { 
        int score = GameManager.PlayerScore;
        string name = InputText.text;
        int level = GameManager.CurrentLevel;
        AddPlayerData(new PlayerData(score, name, level));
        GameManager.PlayerScore = 0;
        GameManager.CurrentScore = 0;
    }
    
    private IEnumerator PostData(System.Object data, string collectionName)
    {
        UnityWebRequest www = new UnityWebRequest(BaseURL + collectionName + ".json", "POST");

        byte[] body = System.Text.Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
        www.uploadHandler = new UploadHandlerRaw(body);
        www.downloadHandler = new DownloadHandlerBuffer();
        www.SetRequestHeader("Content-Type", "application/json");
        
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Player data added to database");
        }
        
        www.Dispose();
    }
}
