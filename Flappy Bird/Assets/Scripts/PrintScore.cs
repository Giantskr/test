using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScore : MonoBehaviour
{
    public Sprite[] number;
    private int i = GameManager.count;
    // Start is called before the first frame update
    void Start()
    {
        for (int k = 0; k < 10; k++)
        {
            GameObject h = new GameObject();
            h.transform.parent = gameObject.transform;
            h.AddComponent<Image>();
            transform.GetChild(k).gameObject.SetActive(false);
        }

       
        //作者：MaximilianLiu
        //来源：CSDN
        //原文：https://blog.csdn.net/MaximilianLiu/article/details/78019947 
    }

    // Update is called once per frame
    void Update()
    {
        for (int h = 0; h < transform.childCount; h++)
        {
            transform.GetChild(h).gameObject.SetActive(false);
        }
        int r = GameManager.count;
        //拿false的子物体激活并给图,数字有多长给长
        for (int i = 0; i < r.ToString().Length; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            transform.GetChild(i).gameObject.GetComponent<Image>().sprite = number[r.ToString()[i] - 48];
        }
       
        //作者：MaximilianLiu
        //来源：CSDN
        //原文：https://blog.csdn.net/MaximilianLiu/article/details/78019947 
    }
}
