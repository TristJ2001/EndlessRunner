using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerDataEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelText;

    public void SetName(string name)
    {
        nameText.text = name;
    }
    
    public void SetScore(int score)
    {
        scoreText.text = score + "";
    }

    public void SetLevel(int level)
    {
        levelText.text = level + "";
    }
}