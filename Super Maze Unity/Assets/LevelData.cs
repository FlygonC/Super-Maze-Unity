using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelScore
{
    public bool completed = false;
    public bool gold = false;

    public int bestTime = 9999;
    public int bestTimeGold = 9999;
}

[System.Serializable]
public class LevelData
{
    public string levelName;
    public string levelSubtitle;
    public LevelObject levelObject;

    //public LevelScore score;
}
