using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medal : MonoBehaviour //控制何时获得何种奖牌，0时没有奖牌
{
    public GameObject gold;
    public GameObject sliver;
    public GameObject Cu;
    // Start is called before the first frame update
    void Start()
    {
        Cu.SetActive(true);
        sliver.SetActive(false);
        gold.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.count==0)
        {
            sliver.SetActive(false);
            Cu.SetActive(false);
            gold.SetActive(false);
        }
        if (GameManager.count > 10)
        {
            sliver.SetActive(true); 
            Cu.SetActive(false);
            gold.SetActive(false);

        }
        if (GameManager.count > 30)
        {
            sliver.SetActive(false);
            Cu.SetActive(false);
            gold.SetActive(true); 

        }
    }

}
