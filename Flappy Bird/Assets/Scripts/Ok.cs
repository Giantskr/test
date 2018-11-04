using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ok : MonoBehaviour
{
    public static int clicktime=1;
    void OnMouseDown()
    {
        GameManager.gamestate = 0;
        BirdFly.input = 0;
        SceneManager.LoadScene("SampleScene");
        GameManager.count = 0;
        TubeCreate.timeswitch = false;
        clicktime = 0;
    }
    //按下ok键重启游戏
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

     
    }
}
