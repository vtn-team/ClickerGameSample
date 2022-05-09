using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    static private GameManager _instance = new GameManager();
    static public GameManager Instance => _instance;
    private GameManager() { }

    int _cookieNum = 0;

    static public int CookieNum => _instance._cookieNum;
    static public void AddCookie(int num) { _instance._cookieNum += num; }
}
