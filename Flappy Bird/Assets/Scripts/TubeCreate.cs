using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeCreate : MonoBehaviour {
    public GameObject Tube;
    private int time = 0; //控制管子出现的计时用变量
    public static bool timeswitch = false;//控制是否开始计时的变量
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (BirdFly.input==1&&timeswitch==false)
        {
            timeswitch = true;
        }
        if (timeswitch == true)
        {
            time += 1;
        }
        if (time ==70&&BirdFly.input==1)
        {
            time = 0;
            Instantiate(Tube);
        }
    }
}
