using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTest : MonoBehaviour {
    public GameObject gameObject;
    public static int play=0;
    



    // Use this for initialization

    // Update is called once per frame
    void FixedUpdate() { 
        

        if (Input.GetMouseButtonDown(0))
        {
            play = 1;
            Destroy();
        }
        
    }
        void Destroy()
        {
            Destroy(gameObject);
            
    }
	}

