using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieCountView : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text _text;
    
    void Update()
    {
        _text.text = GameManager.CookieNum.ToString();
    }
}
