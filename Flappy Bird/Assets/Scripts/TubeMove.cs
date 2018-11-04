using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TubeMove : MonoBehaviour {

    public GameObject bird;
    public AudioSource audioSource;
    private bool pulse = false;
    public static int speed = 3;
    private int afterscore = 0;


	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0.87f, Random.Range(-1.5f, 2.5f), -2.1596f); //将生成的管子放到那个height随机的位置
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
   
        if((this.transform.localPosition.x <-11.5f )&& afterscore==0)//计分判定
        { 
            GameManager.count += 1;
            afterscore = 1;

        }
        if (this.transform.localPosition.x < -15f)//物体销毁判定
        {
            Destroy(gameObject);
        }

            if (pulse == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (pulse == false)
            {
                audioSource.Play();
                pulse = true;//为了让这个步骤只执行1次
                GetComponent<Rigidbody2D>().velocity = Vector2.left * 0;
                BirdFly.input = 2;
                BirdFly.angleswitch = 0;
                GroundMove.speed = 0;
                GameManager.gamestate = 2;
            }
        }
        
    }
}
