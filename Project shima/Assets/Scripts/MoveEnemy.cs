using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed = 1f;                   //歩く速さ
    public float rotationspeed = 1f;    //徘徊途中の方向転換速度
    private float posrange = 5f;          //ランダム範囲
    private Vector3 targetpos;            //目標位置
    private float changetarget = 30f; //方向転換するまでの目標位置との距離
    public GameObject player;           //プレイヤー
    private float targetdistance;         //目標位置までの距離
    private float distancetoplayer;     //プレイヤーまでの距離
 //   private Animator enemyanim;     //敵のアニメーター
 //   private float animspeed;               //アニメーターのスピード

    Vector3 GetRandomPosition(Vector3 currentpos)
    {
        return new Vector3(Random.Range(-posrange + currentpos.x, posrange + currentpos.x), 0, Random.Range(-posrange + currentpos.z, posrange + currentpos.z));
    }
    void haikai()
    {
        if (targetdistance < changetarget) targetpos = GetRandomPosition(transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(targetpos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationspeed);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.Log("haikai");
    }
    void chase()
    {
        Quaternion playerRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, Time.deltaTime * rotationspeed * 10f);
        transform.Translate(Vector3.forward * speed * 2f * Time.deltaTime);
        Debug.Log("chase");
    }
    /*void attack()
    {
        Debug.Log("attack");
    }*/
    void Start()
    {
        targetpos = GetRandomPosition(transform.position);
      //  enemyanim = this.gameObject.GetComponent<Animator>();
      //  animspeed = 0f;
    }
    void Update()
    {
        targetdistance = Vector3.SqrMagnitude(transform.position - targetpos);
        distancetoplayer = Vector3.SqrMagnitude(transform.position - player.transform.position);
         if (distancetoplayer > 50f) {
        haikai();
//        animspeed = speed * 3f;
 //       enemyanim.SetFloat("speed", animspeed);
        }
        else
        if (3f < distancetoplayer && distancetoplayer < 50f)
        {
            chase();
           // animspeed = speed * 10f;
         //  enemyanim.SetFloat("speed", animspeed);
        }
     /*   else
        {
            attack();
            animspeed = 0f;
            enemyanim.SetFloat("speed", animspeed);
            enemyanim.SetFloat("attack");
        }*/
    }
}
