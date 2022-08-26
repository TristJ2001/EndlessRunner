using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCont : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        GameManager.PlayerScore = 0;
        GameManager.CurrentScore = 0;
        GameManager.CurrentLevel = 1;
        SceneManager.LoadScene("Level1");
    }

    public void OnQuitButtonClick()
    {
        Application.Quit(0);
    }

    public void OnLeaderboardButtonClick()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void OnCreditsButtonClick()
    {
        SceneManager.LoadScene("Credits");
    }
}
