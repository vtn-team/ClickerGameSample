using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBuildFactory : MonoBehaviour
{
    [SerializeField] int _id = 0;
    [SerializeField] BuildType _type;
    [SerializeField] float _buildInterval = 0.5f;
    [SerializeField] int _buildNum = 1;
    
    void Start()
    {
        //色変えのためのコード
        Color col = Color.black;
        switch(_type)
        {
            case BuildType.Hand: col = Color.white; break;
            case BuildType.Human: col = Color.yellow; break;
            case BuildType.Farm: col = Color.magenta; break;
            case BuildType.Factory: col = Color.blue; break;
        }
        GetComponent<MeshRenderer>().materials[0].color = col;

        StartCoroutine(BuildCookie());
    }

    IEnumerator BuildCookie()
    {
        while (true)
        {
            if (_buildInterval <= 0.001f) break;
            yield return new WaitForSeconds(_buildInterval);

            GameManager.AddCookie(_type, _buildNum);
        }
    }
}
