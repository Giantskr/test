using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTest : MonoBehaviour {
    public GameObject Tap;
    public GameObject GrayBird;
    public GameObject StartFlappyBird;
    public GameObject New;
    



    // Use this for initialization

    // Update is called once per frame
    void FixedUpdate() {

        if (Input.GetMouseButtonDown(0))
        {
            Destroy();
        }
        
    }
        void Destroy()
        {
            Destroy(Tap);
            Destroy(GrayBird);    
            Destroy(StartFlappyBird);
            Destroy(New);
 
    }
	}

