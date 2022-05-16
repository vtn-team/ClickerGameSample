using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBuildFactory : MonoBehaviour
{
    [SerializeField] int _id = 0;
    [SerializeField] int _having = 0;
    [SerializeField] float _buildInterval = 0.5f;
    [SerializeField] int _buildNum = 1;

    public int Id => _id;
    public int HavCount => _having;
    public void Setup(int havCount)
    {
        _having = havCount;
        if(_having > 0)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(BuildCookie());
    }

    IEnumerator BuildCookie()
    {
        while (true)
        {
            if (_buildInterval <= 0.001f) break;
            yield return new WaitForSeconds(_buildInterval);

            GameManager.AddCookie(_buildNum * _having);
        }
    }
}
