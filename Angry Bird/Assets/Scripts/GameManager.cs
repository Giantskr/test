using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BirdOne;
    public GameObject BirdTwo;
    public GameObject BirdThree;
    public static int states=0;


    // Start is called before the first frame update
    void Start()
    {
        BirdOne.GetComponent<BirdMove>().state = states;
        BirdTwo.GetComponent<BirdMove>().state =states+ 1;
        BirdThree.GetComponent<BirdMove>().state =states+ 2;
    }

    // Update is called once per frame
    void Update()
    {

        BirdOne.GetComponent<BirdMove>().state = states;
        BirdTwo.GetComponent<BirdMove>().state = states + 1;
        BirdThree.GetComponent<BirdMove>().state = states + 2;
    }
}
