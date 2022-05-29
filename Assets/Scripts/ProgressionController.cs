using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionController : MonoBehaviour {

    //Singleton
    public static ProgressionController Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public int xp = 0;
    public int coins = 0;
    public int level = 0;
    public int maxLevel = 6;

    public Dictionary<int, int> MapLevelXP = new Dictionary<int, int>();

    void Start() {

        MapLevelXP.Add(0, 0);
        MapLevelXP.Add(1, 1000);
        MapLevelXP.Add(2, 2000);
        MapLevelXP.Add(3, 3000);
        MapLevelXP.Add(4, 4000);
        MapLevelXP.Add(5, 5000);
        MapLevelXP.Add(6, 6000);


    }

    void UpdateLevel() {
        // Never exceed beyond top level, which is 4.
        int nextLevel = (level + 1) < maxLevel ? level + 1 : maxLevel;

        if (MapLevelXP.ContainsKey(nextLevel) && (xp >= MapLevelXP[nextLevel])) {
            level++;
        }
    }

    int GetXP() {
        return xp;
    }

    int GetXpToNextLevel() {
        // Never exceed beyond top level, which is 4.
        int nextLevel = (level + 1) < maxLevel ? level + 1 : maxLevel;
        return MapLevelXP.ContainsKey(nextLevel) ? MapLevelXP[nextLevel] : xp;
    }

    int GetLevel() {
        return level < maxLevel ? level : maxLevel;
    }


    int GetCoins()
    {
        return coins;
    }

    public void UpdateProgress() {
        Dictionary<string, int> stats = GetStats();

        UpdateLevel();

    }

    public void CompleteToDo(int xpReward)
    {
        xp += xpReward;
        UpdateProgress();
    }

    public void CompleteQuest(int xpReward, int coinReward)
    {
        xp += xpReward;
        coins += coinReward;
        UpdateProgress();
    }


    public Dictionary<string, int> GetStats() {
        Dictionary<string, int> stats = new Dictionary<string, int> {
            { "xp", GetXP() },
            { "base_xp", MapLevelXP[level] },
            { "next_xp", GetXpToNextLevel() },
            { "level", GetLevel() },
            { "coins", GetCoins() }
        };

        return stats;
    }
}
