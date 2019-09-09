using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public static GameManager Instance { get; private set; }

    /// <summary>
    /// 当前人数
    /// </summary>
    private int chessPeople;

    /// <summary>
    /// 当前难度    1=简单 2=中等 3=困难
    /// </summary>
    private int currentLevel;
    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {

    }

    void Update()
    {
        
    }
}
