using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeCreate : MonoBehaviour {
    public GameObject greenTube;
    public GameObject brownTube;
    private GameObject tube;
    public static bool whichtube;
    private int time = 0; //控制管子出现的计时用变量
    public static bool timeswitch = false;//控制是否开始计时的变量
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(whichtube==false)
        {
            tube = greenTube;
        }
        else
        {
            tube = brownTube;
        }
        
        if (BirdFly.input==1&&timeswitch==false)
        {
            timeswitch = true;
        }
        if (timeswitch == true)
        {
            time += 1;
        }
        if (time ==90&&BirdFly.input==1)
        {
            time = 0;
            Instantiate(tube);
        }
    }
}
