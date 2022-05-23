using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    private void Start()
    {
        Load();

        var shop = GameObject.Find("/Canvas/Shop");
        var shopScript = shop.GetComponent<Shop>();
        shopScript.Setup();
    }

    public void Load()
    {
        GameManager.Instance.Load();
    }

    public void Save()
    {
        GameManager.Instance.Save();
    }
}
