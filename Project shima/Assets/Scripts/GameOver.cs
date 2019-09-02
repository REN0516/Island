using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //待ち時間
    public float TimeCount = 2;
    private float a;
    //背景
    public GameObject backGround;
    //GameOver文字
    public GameObject overWord;
    //float alfa;
    float speed = 10f;
    //float red, green, blue;

    void Start()
    {
        backGround.SetActive(false);
        // overWord.SetActive(false);


    
    }

    
    void Update()
    {
        //背景表示
        backGround.SetActive(true);

        //カウント
        TimeCount -= Time.deltaTime; 

        //0秒になったら
        if(TimeCount <= 0)
        {
            //GameOver文字表示
            // overWord.SetActive(true);
            //overWord.GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, speed / 255.0f);
            StartCoroutine(FadePanel());
        }


    }
    IEnumerator FadePanel()
    {

        while (a < 10)
        {
            overWord.GetComponent<Image>().color += new Color(0, 0, 0, 0.001f);
            a += 0.01f;
            yield return null;
        }
    }
}
