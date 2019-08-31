using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //待ち時間
    public float TimeCount = 3;

    //背景
    public GameObject backGround;
    //GameOver文字
    public GameObject overWord;

    void Start()
    {
        backGround.SetActive(false);
        overWord.SetActive(false);

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
            overWord.SetActive(true);

        }


    }
}
