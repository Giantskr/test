using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    public GameObject Bird;
    public GameObject Tube;
    private int score=0;
    public GameObject zero;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    private bool zeroswitch = true;
    private bool scoreswitch = true;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)&&zeroswitch==true)
        {
            Instantiate(zero);
            zeroswitch = false;
        }

        Vector3 v = Bird.transform.localPosition;
        Vector3 v2 = Tube.transform.position;
        
      
    }
}
