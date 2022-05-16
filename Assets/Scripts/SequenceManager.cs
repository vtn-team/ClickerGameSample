using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    private void Start()
    {
        Load();

        //後処理
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
