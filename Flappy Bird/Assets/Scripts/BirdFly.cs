using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour {
   
    public GameObject Bird;
    public AudioSource audioSource;
    public static int input=0;                //0 用于游戏开始前 ，1 用于游戏进行中 ，2用于小鸟撞到管子后
    private float updowntime=0;      //用于鸟上下摇摆的计时
    private float height;
    private int angletime=0;              //用于控制鸟的角度的三个变量
    public static int angleswitch = 0;
    public static int angle;
 
    // Use this for initialization
    void Start () {
        angle = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ok.clicktime += 1; //为了让游戏重新开始时和重新打开游戏一样
        }
        Bird.transform.eulerAngles = new Vector3(0, 0,angle);
        if (angleswitch == 1)
        {
            angletime += 1;
        }
        if (angletime>0&&angletime <= 20)
        {
            angle = 30;
        }
        if ((angletime>20)&&(angletime<80) )
        {
            angle = 30-2*(angletime-20);
        }
        if (angletime >= 80)
        {
            angle = -90;
        }

        if (input == 0)
        {
            angle = 0;
            angletime = 0;
            angleswitch = 0;
            updowntime += 1;
            height = 0.2f*Mathf.Sin(updowntime/10);
            Bird.GetComponent<Transform>().position = new Vector3(-1.15f, 0.8f+height, -0.314f); //用sin函数实现鸟儿上下漂浮效果
        }
        if(input==0&& Input.GetMouseButtonDown(0)&& GameManager.gamestate == 0&&Ok.clicktime>1) //游戏开始判定，可能有冗余
        {
            input = 1;
        }
        if (input==1&& Input.GetMouseButtonDown(0))
        {
            GameManager.gamestate = 1;  
            angleswitch = 1;
            angletime = 0;
            angle = 30;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;//实现往上飞
            GetComponent<Rigidbody2D>().gravityScale = 1;
            audioSource.Play();

        }
    }
   
}
//SceneManager.LoadScene("SampleScene");之后会用到