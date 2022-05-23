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
    List<UpgradeData> _upgrades = new List<UpgradeData>();
    FactoryManager _factoryMan = null;

    static public int CookieNum => _instance._cookieNum;
    
    static public FactoryManager Factory => _instance._factoryMan;
    static public List<UpgradeData> UpgradeInfo => _instance._upgrades;


    static public void AddCookie(BuildType type, int num)
    {
        //TODO: Upgrade

        _instance._cookieNum += num;
    }

    static public void Purchase(ShopItemTable item, int cost)
    {
        _instance._cookieNum -= cost;
        switch(item.Type)
        {
            case ItemType.Factory:
                _instance._factoryMan.Purchase(item.TargetId);
                break;

            case ItemType.Upgrade:
                //TODO:
                break;
        }
    }

    public void Load()
    {
        //デバッグ時に楽なのでdataPathにしてるけど、persistentDataPathが適切
        var save = LocalData.Load<SaveData>(Application.dataPath + "/save.json");
        if(save == null)
        {
            save = new SaveData();
        }

        _cookieNum = save.CookieNum;
        
        var root = GameObject.Find("/Factory");
        _factoryMan = root.GetComponent<FactoryManager>();
        int cc = _factoryMan.transform.childCount;
        for (int i = 0; i < cc; ++i)
        {
            GameObject.Destroy(_factoryMan.transform.GetChild(i).gameObject);
        }
        _factoryMan.Setup(save.Factory);
    }

    public void Save()
    {
        SaveData save = new SaveData();

        //Loadが呼ばれている必要がある。ちょっとイケてない
        _factoryMan.Save(save);
        save.CookieNum = _cookieNum;

        //デバッグ時に楽なのでdataPathにしてるけど、persistentDataPathが適切
        LocalData.Save<SaveData>(Application.dataPath + "/save.json", save);
    }
}
