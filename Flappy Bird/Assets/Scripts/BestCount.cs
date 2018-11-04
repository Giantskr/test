using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using UnityEngine.UI;

namespace FileApplication{

public class BestCount : MonoBehaviour {//记录最佳成绩
        public static int bestcount;
        public Sprite[] number;
        private int i = bestcount;
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



            using (StreamReader sr = new StreamReader("C:/BestCount.txt"))
                {
                string line;

                // 从文件读取并显示行，直到文件的末尾 
                while ((line = sr.ReadLine()) != null)
                {
                    bestcount= Int32.Parse(line);
                }
            }
        }
         void Update()
        {
            Debug.Log("b" + bestcount);
            if (bestcount < GameManager.count)
            {
                bestcount = GameManager.count;
                string strcount = bestcount.ToString();
                string[] names = new string[] { strcount };
                using (StreamWriter sw = new StreamWriter("C:/BestCount.txt"))
                {
                    foreach (string s in names)
                    {
                        sw.WriteLine(s);

                    }
                }
            }
            for (int h = 0; h < transform.childCount; h++)
            {
                transform.GetChild(h).gameObject.SetActive(false);
            }
            int r = bestcount;
            //拿false的子物体激活并给图,数字有多长给长
            for (int i = 0; i < r.ToString().Length; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                transform.GetChild(i).gameObject.GetComponent<Image>().sprite = number[r.ToString()[i] - 48];
            }
        }
    }
}

//C:\Users\99423\Documents\flappy