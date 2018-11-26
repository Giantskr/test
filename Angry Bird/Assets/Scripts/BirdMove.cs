using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BirdMove : MonoBehaviour
{
    LineRenderer lineRenderer;
    public GameObject Bird;
    public GameObject BirdSon;
    public GameObject Holder;
    public GameObject StartPosition;

    private Animator animator;

    private AudioSource audioSource;
    public AudioClip yell1;
    public AudioClip yell2;
    public AudioClip fly;
    public AudioClip collisionSound;
    public AudioClip shot;
    public AudioClip slingshot;

    private bool isDrag=false;
    Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
    Vector3 mousePositionOnScreen;
    Vector3 arrowspeed = new Vector3(10,5,0);
    private float deltaX;
    private float deltaY;//用于放鼠标与锚点的相对位置关系
    public int state;//用于判断鸟是否上弓
    private float handerDeltaX;
    private float handerDeltaY;//用于放托与锚点的相对位置关系
    private float holderRotation;
    private float birdDeltaX;
    private float birdDeltaY;//用于鸟与锚点的相对位置关系
    private int yellOrJump;
    private int betweenTwoAni;
    public int between;
    private bool getReady;
    private bool Rolled=false;

    // Start is called before the first frame update
    void Start()
    {
        animator = BirdSon.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Holder.transform.position = new Vector3(-4.589f, -1.48f, 0);
    }
    private void OnMouseDrag()
    {
        if (state == 0)
        {
            //画线
            lineRenderer = GetComponent<LineRenderer>();
            Vector3[] vector3s = new Vector3[2];
            vector3s[0] = new Vector3(-4.75f, -1.35f, -0.2f);
            vector3s[1] = Holder.transform.position;
            lineRenderer.SetPositions(vector3s);

            //画线
            if (isDrag == false)
            {
                audioSource.PlayOneShot(slingshot);
                isDrag = true;
            }

            mousePositionOnScreen = Input.mousePosition;
            mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen); //获取鼠标的世界坐标

            if (deltaX * deltaX > 0)
            {
                if (deltaX <= 0)
                {
                    holderRotation = (180 / Mathf.PI) * Mathf.Atan(birdDeltaY / birdDeltaX) - 15;
                }
                else
                {
                    holderRotation = (180 / Mathf.PI) * Mathf.Atan(birdDeltaY / birdDeltaX) - 195;
                }
                Holder.transform.eulerAngles = new Vector3(0, 0, holderRotation);
                Holder.transform.position = new Vector3(handerDeltaX - 4.589f, handerDeltaY - 1.48f, -0.1f);
            }

            if (deltaX * deltaX + deltaY * deltaY <= 0.81) //如果鼠标距锚点小等于0.9 ，鼠标位置等于鸟的位置
            {
                transform.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, -0.1f);

            }
            if (deltaX * deltaX + deltaY * deltaY > 0.81) //如果鼠标距锚点距大于0.9 ，则……
            {

                // float deltax= Math.Abs(deltaX); float deltay = Math.Abs(deltaY);
                double vectory = Math.Sqrt(deltaX * deltaX + deltaY * deltaY); //取得鼠标到锚点向量的模
                float vectory1 = (float)Math.Abs(vectory);//数据类型转换
                float scalei = 0.9f / vectory1;  //Debug.Log(vectory1);//求得0.9与向量的比值
                Bird.GetComponent<Rigidbody2D>().position = new Vector3((scalei * deltaX) - 4.589f, (scalei * deltaY) - 1.48f, -0.1f); //实现鸟限制在一定范围的同时 指向鼠标位置
            }
        }
    }
    private void OnMouseUp()
    {
        if (state == 0)
        {
            arrowspeed = new Vector3(-15 * birdDeltaX, -15 * birdDeltaY, 0);
            Bird.GetComponent<Rigidbody2D>().gravityScale = 0.7f;
            Bird.GetComponent<Rigidbody2D>().velocity = arrowspeed;
            audioSource.PlayOneShot(fly);
            BirdSon.GetComponent<Animator>().SetTrigger("Fly");
            audioSource.PlayOneShot(shot);
            Holder.transform.position = new Vector3(-4.589f, -1.48f, 0);
            Holder.transform.eulerAngles = new Vector3(0, 0, 78);
            GetComponent<LineRenderer>().enabled = false;         
              GameManager.states -= 1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(state==0&&getReady==false)
        {
            if (Rolled == false)
            {
                animator.SetTrigger("Rolling");
                Rolled = true;
            }
            transform.position = Vector3.MoveTowards(BirdSon.transform.position, StartPosition.transform.position, 5 * Time.deltaTime);
           
            if (BirdSon. transform.position.x<=-4.75f)
            getReady = true;
        }
        betweenTwoAni += 1;
        if (state == 0)
        {
            deltaX = mousePositionInWorld.x + 4.589f;
            deltaY = mousePositionInWorld.y + 1.48f;
            birdDeltaX = Bird.transform.position.x + 4.589f;
            birdDeltaY = Bird.transform.position.y + 1.48f;
            double vectory = Math.Sqrt(birdDeltaX * birdDeltaX + birdDeltaY * birdDeltaY); //取得鼠标到锚点向量的模
            float vectory1 = (float)Math.Abs(vectory);//数据类型转换
            handerDeltaX = birdDeltaX + 0.2f * (birdDeltaX / vectory1);
            handerDeltaY = birdDeltaY + 0.2f * (birdDeltaY / vectory1);
        }
        else//进行在地面的动画
        {
            if (betweenTwoAni > between)
            {
                Random rd = new Random();
                yellOrJump = rd.Next(1, 3);
                if (yellOrJump == 1)
                {
                    animator.SetTrigger("Jump");
                }
                if (yellOrJump == 2)
                {
                    animator.SetTrigger("Yell");

                }
                
                betweenTwoAni = 0;
            }

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdSon.GetComponent<Animator>().SetTrigger("Collision");
    }
}

