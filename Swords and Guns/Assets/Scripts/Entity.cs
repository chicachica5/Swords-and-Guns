using UnityEngine;
using System.Collections.Generic;
[System.Serializable]

public struct Stat
{
    public string name;
    public int stat;
}

public class Entity : MonoBehaviour
{
    [SerializeField] List<Stat> _entityStats = new();
  
    public void AddEntityStat(Stat stat)
    {
        _entityStats.Add(stat);
    }

    public Stat GetEntityStat(string name)
    {
        if(_entityStats.Count == 0) return new Stat();

        for(int i = 0; i < _entityStats.Count; i++)
        {
            if(_entityStats[i].name == name) return _entityStats[i];
        }

        Stat s;
        s.name = "";
        s.stat = 0;
        return s;
    }
}
