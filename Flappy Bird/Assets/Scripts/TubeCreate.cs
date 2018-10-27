using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeCreate : MonoBehaviour {
    public GameObject Tube;
    private int time = 0;
    private bool timeswitch = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            timeswitch = true;
        }
        if (timeswitch == true)
        {
            time += 1;
        }
        if (time ==70)
        {
            time = 0;
            Instantiate(Tube);
        }
    }
}
