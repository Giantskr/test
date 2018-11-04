using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject startUI; 
    public GameObject endUI;
    public GameObject countBoard;
    public GameObject BestCount;
    public static int count = 0;
    public static int gamestate;  //用一种智障的方式控制三种游戏状态
    public enum GameState   //三个游戏状态
    {
        start,
        playing,
        end
    }
    public static GameState gameState = new GameState(); 

    


    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.start;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (gamestate == 0) { gameState = GameState.start; }
        if (gamestate==1) { gameState = GameState.playing; }
        if (gamestate==2) { gameState = GameState.end; }
        switch (gameState)
        {
            case GameState.start:
                startUI.SetActive(true);
                endUI.SetActive(false);
                countBoard.SetActive(false);
                BestCount.SetActive(false);
                break;
            case GameState.playing:
                TubeMove.speed = 3;
                startUI.SetActive(false);
                countBoard.SetActive(false);
                BestCount.SetActive(false);
                break;
            case GameState.end:

                TubeMove.speed = 0; //让那些克隆出来的管子都停下
                endUI.SetActive(true);
                countBoard.SetActive(true);
                BestCount.SetActive(true);
                TubeCreate.timeswitch = false;
                break;
        }
    }
    
}
