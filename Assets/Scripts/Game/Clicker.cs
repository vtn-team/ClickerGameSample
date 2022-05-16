using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] int _addNum = 1;

    void Update()
    {
        if(Input.anyKeyDown)
        {
            GameManager.AddCookie(_addNum);
        }
    }
}
