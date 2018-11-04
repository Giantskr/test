using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {
    public GameObject ground;
    public AudioSource audioSource;
    public static int speed;//给地面一个移动速度
    private bool pulse = false;
    // Use this for initialization
    void Start () {
        speed = 3;
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }
	
	// Update is called once per frame
	void Update () {
        if(speed==0)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Respawn")//碰到那个褐色柱子之后回到原位
        {
            transform.position = new Vector3(0.0f, -0.2f, -3f);
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;

        }
        if (collision.gameObject.tag == "Player")
        {
            if (pulse == false)
            {
                speed = 0;
                TubeMove.speed = 0;
                audioSource.Play();
                GameManager.gamestate = 2;
                pulse = true;
                BirdFly.input = 2;
                BirdFly.angleswitch = 0;
            }
        }
    }
    }
