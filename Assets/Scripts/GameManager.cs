using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager
{
    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;
    private GameManager() { }
    
    int _cookieNum = 0;
    List<FactoryData> _factories = new List<FactoryData>();
    List<UpgradeData> _upgrades = new List<UpgradeData>();

    static public int CookieNum => _instance._cookieNum;
    static public void AddCookie(int num) { _instance._cookieNum += num; }
    
    static public List<FactoryData> FactoryInfo => _instance._factories;
    static public List<UpgradeData> UpgradeInfo => _instance._upgrades;


    public void Load()
    {
        //デバッグ時に楽なのでdataPathにしてるけど、persistentDataPathが適切
        var save = LocalData.Load<SaveData>(Application.dataPath + "/save.json");
        if(save == null)
        {
            save = new SaveData();
        }

        _cookieNum = save.CookieNum;
        _factories = save.Factory;

        //オブジェクト拾ってきて、持ってるやつを稼働させる
        //もっといいやり方はある、次書き換える
        var root = GameObject.Find("/Factory");
        var factoryList = root.GetComponentsInChildren<AutoBuildFactory>(true).ToList();
        factoryList.ForEach(f => {
            var find = _factories.Find(s => s.Id == f.Id);
            if(find != null)
            {
                f.Setup(find.Num);
            }
        });
    }

    public void Save()
    {
        SaveData save = new SaveData();
        
        //オブジェクト拾ってきて、持ってるやつを稼働させる
        //もっといいやり方はある、次書き換える
        var root = GameObject.Find("/Factory");
        var factoryList = root.GetComponentsInChildren<AutoBuildFactory>().ToList();
        factoryList.ForEach(f => {
            save.Factory.Add(new FactoryData() { Id = f.Id, Num = f.HavCount });
        });

        save.CookieNum = _cookieNum;

        //デバッグ時に楽なのでdataPathにしてるけど、persistentDataPathが適切
        LocalData.Save<SaveData>(Application.dataPath + "/save.json", save);
    }
}
