using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {
    public GameObject Ground;
    public AudioSource audioSource;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * 3;
    }
	
	// Update is called once per frame
	void Update () {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            transform.position = new Vector3(0.0f, -0.2f, -3f);
            GetComponent<Rigidbody2D>().velocity = Vector2.left * 3;
        }
    }
    }
