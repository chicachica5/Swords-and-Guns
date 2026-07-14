using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    int sceneDifficulty = 10;
    int actualDifficulty = 0;
    int futureDifficulty = 0;

    int timeToReleaseMin = 60;
    int timeToReleaseMax = 600;

    [SerializeField] DifficultyManager _diffManager;
    [SerializeField] List<EnemyDifficulty> _enemyDiff = new();
    
    [SerializeField] List<TimedEnemy> _futureEnemy = new();
    void Start()
    {
        GetEnemyDifficulties();
    }

    void Update()
    {
        if(futureDifficulty + actualDifficulty < sceneDifficulty)
        {
            AddEnemy();
        }
    }

    void FixedUpdate()
    {
        for(int i = 0; i < _futureEnemy.Count; i++)
        {
            _futureEnemy[i].timer -= 1;
            if(_futureEnemy[i].timer <= 0)
            {
                //CREATE ENEMY
                GameObject ins = Instantiate(_futureEnemy[i].prefab, _futureEnemy[i].position, Quaternion.identity);

                ins.transform.SetParent(gameObject.transform);

                actualDifficulty+= _futureEnemy[i].difficulty;
                futureDifficulty-= _futureEnemy[i].difficulty;

                _futureEnemy.RemoveAt(i);
                i--;
            }
        }
    }

    void AddEnemy()
    {
        if (_enemyDiff[0].diff + futureDifficulty + actualDifficulty > sceneDifficulty) return; // check if the minimum monster diff can be added
        int chosen;

        while(true)
        {
            chosen = Random.Range(0, _enemyDiff.Count);
            if(_enemyDiff[chosen].diff + futureDifficulty + actualDifficulty <= sceneDifficulty) break;
        }

        TimedEnemy en = new TimedEnemy(Random.Range(timeToReleaseMin, timeToReleaseMax), _enemyDiff[chosen].diff, _enemyDiff[chosen].prefab);

        _futureEnemy.Add(en);
        futureDifficulty += _enemyDiff[chosen].diff;
    }

    void GetEnemyDifficulties()
    {
        _enemyDiff = _diffManager.GetEnemyList();
    }
}

public class TimedEnemy
{
    public int timer;
    public int difficulty;
    public GameObject prefab;

    public Vector3 position;

    public TimedEnemy(int timer, int difficulty, GameObject prefab)
    {
        this.timer = timer;
        this.difficulty = difficulty;
        this.prefab = prefab;
        position = new Vector3(0, 0, 0);
    }
}