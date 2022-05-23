using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    [Serializable]
    class FactorySetting
    {
        public int Id;
        public GameObject Prefab;
    }
    [SerializeField] List<FactorySetting> _factorySettings;

    List<FactoryData> _factories = new List<FactoryData>();

    float _rad = 0;
    int _createCount = 0;

    public void Setup(List<FactoryData> savedata)
    {
        _factories = savedata;

        foreach (var f in _factories)
        {
            for (int i = 0; i < f.Level; ++i)
            {
                Purchase(f.Id, true);
            }
        }
    }

    public void Save(SaveData data)
    {
        data.Factory = _factories;
    }

    public void Purchase(int Id, bool isInit = false)
    {
        var prefab = _factorySettings.Where(s => s.Id == Id).Select(s => s.Prefab).Single();
        var obj = Instantiate(prefab, this.transform);

        if (!isInit)
        {
            bool isFind = false;
            for (int i = 0; i < _factories.Count; ++i)
            {
                if (_factories[i].Id != Id) continue;

                _factories[i].Level++;
                isFind = true;
                break;
            }
            if (!isFind)
            {
                _factories.Add(new FactoryData() { Id = Id, Level = 1 });
            }
        }

        float r = (float)_createCount / 10.0f;
        obj.transform.localPosition = new Vector3(r * Mathf.Cos(_rad), 0, r * Mathf.Sin(_rad));
        _rad += 0.1f;
        _createCount++;
    }

    public int GetLevel(int Id)
    {
        var data = _factories.Where(f => f.Id == Id);
        if (data.Count() > 0)
        {
            return data.Single().Level;
        }
        else
        {
            return 0;
        }
    }
}
