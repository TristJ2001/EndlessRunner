using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endScore;
    
    private void Awake()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        endScore.text = $"GAME OVER \n Score: {GameManager.PlayerScore} \n Level: {GameManager.CurrentLevel}";
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
