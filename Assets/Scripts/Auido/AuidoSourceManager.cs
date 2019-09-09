using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuidoSourceManager : MonoBehaviour
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public static AuidoSourceManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
