using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public static UIManager Instance { get; private set; }

    /// <summary>
    /// 存储所有游戏的Panel   0.主界面 1.选择模式 3.选择人机难度 4.游戏界面 5.单人页面 6.联网页面
    /// </summary>
    public GameObject[] panels;

    /// <summary>
    /// 游戏按钮
    /// </summary>
    private Button btn_personal;
    private Button btn_net;
    private Button btn_quit;
    private Button btn_rjfight;
    private Button btn_rrfight;
    private Button btn_easyRj;
    private Button btn_commonRj;
    private Button btn_diffcultRj;

    void Start() 
    {
        Instance = this;

        //开始界面的按钮
        btn_personal = panels[0].transform.Find("btn_personal").GetComponent<Button>();
        btn_net = panels[0].transform.Find("btn_net").GetComponent<Button>();
        btn_quit = panels[0].transform.Find("btn_quit").GetComponent<Button>();

        //绑定开始界面按钮事件
        btn_personal.onClick.AddListener(OnPersonalBtnClick);
        btn_net.onClick.AddListener(OnNetBtnClick);
        btn_quit.onClick.AddListener(OnQuitBtnClick);


        //选择模式按钮
        btn_rjfight = panels[1].transform.Find("selectmode/btn_rj").GetComponent<Button>();
        btn_rrfight = panels[1].transform.Find("selectmode/btn_rr").GetComponent<Button>();

        //绑定选择模式按钮事件
        btn_rjfight.onClick.AddListener(OnRJBtnClick);
        btn_rrfight.onClick.AddListener(OnRRBtnClick);


        //选择难度按钮
        btn_easyRj = panels[1].transform.Find("selectdiff/btn_jd").GetComponent<Button>();
        btn_commonRj = panels[1].transform.Find("selectdiff/btn_yb").GetComponent<Button>();
        btn_diffcultRj = panels[1].transform.Find("selectdiff/btn_kn").GetComponent<Button>();

        //绑定难度选择按钮事件
        btn_easyRj.onClick.AddListener(OnEasyBtnClick);
        btn_commonRj.onClick.AddListener(OnCommonBtnClick);
        btn_diffcultRj.onClick.AddListener(OnDiffcultClick);
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 单机模式
    /// </summary>
    private void OnPersonalBtnClick()
    {
        panels[0].SetActive(false);
        panels[1].SetActive(true);
        panels[4].SetActive(false);
    }

    /// <summary>
    /// 人机对战
    /// </summary>
    private void OnRJBtnClick()
    {
        panels[2].SetActive(false);
        panels[3].SetActive(true);
    }

    /// <summary>
    /// 双人对战(面对面)
    /// </summary>
    private void OnRRBtnClick()
    {
        panels[1].SetActive(false);
        panels[4].SetActive(true);
        panels[5].SetActive(true);
        panels[6].SetActive(false);
    }

    /// <summary>
    /// 简单人机
    /// </summary>
    private void OnEasyBtnClick()
    {
        print("easy");
    }

    /// <summary>
    /// 一般人机
    /// </summary>
    private void OnCommonBtnClick()
    {
        print("common");
    }

    /// <summary>
    /// 困难人机
    /// </summary>
    private void OnDiffcultClick()
    {
        print("diffcult");
    }

    /// <summary>
    /// 联网模式
    /// </summary>
    private void OnNetBtnClick()
    {
        panels[0].SetActive(false);
        panels[4].SetActive(true);
        panels[6].SetActive(true);
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    private void OnQuitBtnClick()
    {
        Application.Quit();
    }
}
