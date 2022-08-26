using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int score;
    public string name;
    public int level;

    public PlayerData(int score, string name, int level)
    {
        this.score = score;
        this.name = name;
        this.level = level;
    }
}
