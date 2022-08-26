using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public TextMeshProUGUI elText;
    public TextMeshProUGUI score;
    public TextMeshProUGUI level;
    private int rand;

    public static GameManager _instance;

    private static int currentLevel = 1;
    public static int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }

    private static bool isInvis;
    public static bool IsInvis
    {
        get { return isInvis; }
        set { isInvis = value; }
    }
    
    private static bool extraLife;
    public static bool ExtraLife
    {
        get { return extraLife;}
        set { extraLife = value; }
    }
    
    private static int currentScore;
    public static int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }
    
    private static int playerScore;
    public static int PlayerScore
    {
        get { return playerScore;}
        set { playerScore = value; }
    }
    
    void Start()
    {
        if (_instance != null)
        {
            Destroy(_instance);
            return;
        }
        _instance = this;

        currentLevel = CurrentLevel;
        extraLife = ExtraLife;
        level.text = $"Level: {CurrentLevel}";
        isInvis = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        score.text = $"{PlayerScore}";

        if (ExtraLife)
        {
            elText.text = "Extra life";
        }
        else
        {
            elText.text = "";
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
            CurrentLevel = 1;
            CurrentScore = 0;
            PlayerScore = 0;
        }

        if (isInvis)
        {
            ExtraLife = false;
            elText.text = "Invisible";
            player.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(InvisTimer(2));
        }
    }
    
    //Invis Pickup Coroutine
    IEnumerator InvisTimer (int seconds) {
        int counter = seconds;
        while (counter > 0) {
            yield return new WaitForSeconds (1);
            counter--;
        }
        player.GetComponent<MeshRenderer>().enabled = true;
        isInvis = false;
        elText.text = "";
    }

    private void OnEnable()
    {
        PrefabController.OnPrefabPassedAction += OnPrefabPassedAction;
        PiranhaCont.OnPiranhaPassedAction += OnPiranhaPassedAction;
        PenguinCont.OnPenguinPassedAction += OnPenguinPassedAction;
        PPickup.OnPointsPickupActivated += OnPointsPickupActivated;
        ELCont.OnExtraLifeActivated += OnExtraLifeActivated;
        InvisPickip.OnInvisPickupActivated += OnInvisPickupActivated;
        //Boss Spawning event in SpawnPrefabs and SpawnPrefabs2
        B1ProjCont.OnBoss1DefeatedAction += OnBoss1DefeatedAction;
        ShockwaveCont.OnBoss2DefeatedAction += OnBoss2DefeatedAction;
    }

    private void OnDisable()
    {
        PrefabController.OnPrefabPassedAction -= OnPrefabPassedAction;
        PiranhaCont.OnPiranhaPassedAction -= OnPiranhaPassedAction;
        PenguinCont.OnPenguinPassedAction -= OnPenguinPassedAction;
        PPickup.OnPointsPickupActivated -= OnPointsPickupActivated;
        ELCont.OnExtraLifeActivated -= OnExtraLifeActivated;
        InvisPickip.OnInvisPickupActivated -= OnInvisPickupActivated;
        B1ProjCont.OnBoss1DefeatedAction -= OnBoss1DefeatedAction;
        ShockwaveCont.OnBoss2DefeatedAction -= OnBoss2DefeatedAction;
    }

    private void OnPrefabPassedAction()
    {
        if (PlayerScore == CurrentScore)
        {
            PlayerScore++;
        }
    }
    
    private void OnPiranhaPassedAction()
    {
        if (PlayerScore == CurrentScore)
        {
            PlayerScore++;
        }
    } 
    
    private void OnPenguinPassedAction()
    {
        if (PlayerScore == CurrentScore)
        {
            PlayerScore++;
        }
    }

    private void OnPointsPickupActivated()
    {
        SFXManager._instance.PlaySound("Pickup_Coin");
        PlayerScore += 5;
        CurrentScore += 5;
    }
    
    private void OnExtraLifeActivated ()
    {
        SFXManager._instance.PlaySound("Powerup4");
        ExtraLife = true;
        Debug.Log("Extra Life");
    }
    
    private void OnInvisPickupActivated()
    {
        IsInvis = true;
    }

    private void OnBoss1DefeatedAction()
    {
        CurrentScore += 100;
        PlayerScore += 100;
        CurrentLevel += 1;
        level.text = $"Level: {CurrentLevel}";
        
        if (currentLevel == 2)
        {
            SceneManager.LoadScene("Scene2");
        }
        else
        {
            ChooseScene();
        }
    }

    private void OnBoss2DefeatedAction()
    {
        CurrentScore += 100;
        PlayerScore += 100;
        CurrentLevel += 1;
        level.text = $"Level: {CurrentLevel}";
        
        ChooseScene();
    }

    private void ChooseScene()
    {
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            SceneManager.LoadScene("Level1");
        }
        else 
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}
