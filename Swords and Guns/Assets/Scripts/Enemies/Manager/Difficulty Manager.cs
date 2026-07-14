using UnityEngine;
using System.Collections.Generic;
[System.Serializable]

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] List<EnemyDifficulty> _enemyDiff = new();

    public void AddEnemyDifficulty(EnemyDifficulty enemy)
    {
        _enemyDiff.Add(enemy);
    }

    public EnemyDifficulty GetEnemyDiff(string name)
    {
        for(int i = 0; i < _enemyDiff.Count; i++)
        {
            if(_enemyDiff[i].name == name) return _enemyDiff[i];
        }

        EnemyDifficulty s;
        s.name = "";
        s.diff = 0;
        s.prefab = null;
        return s;
    }

    public List<EnemyDifficulty> GetEnemyList()
    {
        return _enemyDiff;
    }
}

[System.Serializable]
public struct EnemyDifficulty
{
    public string name;
    public int diff;
    public GameObject prefab;   
}
