using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public static GameManager Instance { get; private set; }

    /// <summary>
    /// 当前对战人数      PVE 1 PVP 2 联网 3
    /// </summary>
    private int chessPeople;

    /// <summary>
    /// 当前难度         简单 1 一般 2 困难 3
    /// </summary>
    private int currentLevel;

    /// <summary>
    /// 数据
    /// </summary>
    public int[,] chessBoard;
    public GameObject[,] boardGrid;
    private const float gridHeight = 56.78f;
    private const float gridWidth = 56.78f;
    private const int gridTotalNum = 90;

    /// <summary>
    /// 资源
    /// </summary>
    public GameObject gridGo;
    public GameObject chessGo;
    public Sprite[] sprites;

    /// <summary>
    /// 引用
    /// </summary>
    public GameObject boardGo; //棋盘


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        if(chessPeople==1)
        {

        }else if(chessPeople==2)
        {

        }
        else
        {

        }
        ResetGame();
    }

    void Update()
    {
        
    }

    private void ResetGame()
    {
        //初始化棋盘数组
        chessBoard = new int[10, 9]
        {
            {2,3,6,5,1,5,6,3,2},
            {0,0,0,0,0,0,0,0,0},
            {0,4,0,0,0,0,0,4,0},
            {7,0,7,0,7,0,7,0,7},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {14,0,14,0,14,0,14,0,14},
            {0,11,0,0,0,0,0,11,0},
            {0,0,0,0,0,0,0,0,0},
            {9,10,13,12,8,12,13,10,9},
        };

        //初始化棋盘游戏物体数组
        boardGrid = new GameObject[10,9];
        InitGrid();
    }

    /// <summary>
    /// 初始化棋盘
    /// </summary>
    private void InitGrid()
    {
        float posX = 0;
        float posY = 0;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                GameObject itemGo = Instantiate(gridGo);
                itemGo.transform.SetParent(boardGo.transform);
                itemGo.name = "Item[" + i.ToString() + "," + j.ToString() + "]";
                itemGo.transform.localPosition = new Vector3(posX,posY,0);
                posX += gridWidth;
                if(posX >= gridWidth * 9)
                {
                    posX = 0;
                    posY -= gridHeight;
                }
                itemGo.GetComponent<ChessOrGrid>().xIndex = i;
                itemGo.GetComponent<ChessOrGrid>().yIndex = j;
                boardGrid[i, j] = itemGo;
            }
        }
        InitChess();
    }

    /// <summary>
    /// 初始化棋子
    /// </summary>
    private void InitChess()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                //拿到对应位置的格子
                GameObject gridItem = boardGrid[i, j];

                switch (chessBoard[i,j])
                {
                    case 1:
                        CreatChess(gridItem, "b_jiang", sprites[0], false);
                        break;
                    case 2:
                        CreatChess(gridItem, "b_che", sprites[1], false);
                        break;
                    case 3:
                        CreatChess(gridItem, "b_ma", sprites[2], false);
                        break;
                    case 4:
                        CreatChess(gridItem, "b_pao", sprites[3], false);
                        break;
                    case 5:
                        CreatChess(gridItem, "b_xiang", sprites[4], false);
                        break;
                    case 6:
                        CreatChess(gridItem, "b_shi", sprites[5], false);
                        break;
                    case 7:
                        CreatChess(gridItem, "b_zu", sprites[6], false);
                        break;



                    case 8:
                        CreatChess(gridItem, "r_jiang", sprites[7], true);
                        break;
                    case 9:
                        CreatChess(gridItem, "r_che", sprites[8], true);
                        break;
                    case 10:
                        CreatChess(gridItem, "r_ma", sprites[9], true);
                        break;
                    case 11:
                        CreatChess(gridItem, "r_pao", sprites[10], true);
                        break;
                    case 12:
                        CreatChess(gridItem, "r_xiang", sprites[11], true);
                        break;
                    case 13:
                        CreatChess(gridItem, "r_shi", sprites[12], true);
                        break;
                    case 14:
                        CreatChess(gridItem, "r_zu", sprites[13], true);
                        break;
                }
            }
        }
    }


    /// <summary>
    /// 创建单个棋子的方法
    /// </summary>
    /// <param name="gridItem">所属的格子</param>
    /// <param name="chessName">棋子的名字</param>
    /// <param name="chessSprite">棋子的精灵</param>
    /// <param name="isRedChess">是否是红色棋子</param>
    private void CreatChess(GameObject gridItem,string chessName,Sprite chessSprite,bool isRedChess)
    {
        GameObject chessItem = Instantiate(chessGo);
        chessItem.transform.SetParent(gridItem.transform);
        chessItem.transform.localPosition = Vector3.zero;
        chessItem.transform.localScale = Vector3.one;
        chessItem.GetComponent<Image>().sprite = chessSprite;
        gridItem.GetComponent<ChessOrGrid>().isRedChess=isRedChess;
    }
}
