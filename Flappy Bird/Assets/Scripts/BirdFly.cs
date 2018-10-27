using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour {
   
    public GameObject Bird;
    public AudioSource audioSource;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            audioSource.Play();


        }
    }
}
