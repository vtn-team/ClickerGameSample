using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBuildCookie : MonoBehaviour
{
    [SerializeField] float _buildInterval = 0.5f;
    [SerializeField] int _buildNum = 1;

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

            GameManager.AddCookie(_buildNum);
        }
    }
}
