using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed = 1f;
    public float rotationspeed = 1f;
    public float posrange = 10f;
    private Vector3 targetpos;
    private float changetarget = 50f;
    public GameObject player;
    private float targetdistance;
    private float distancetoplayer;
    Vector3 GetRandomPosition(Vector3 currentpos)
    {
        return new Vector3(Random.Range(-posrange + currentpos.x, posrange + currentpos.x), 0, Random.Range(-posrange + currentpos.z, posrange + currentpos.z));
    }
  /*  void haikai()
    {
        if (targetdistance < changetarget) targetpos = GetRandomPosition(transform.position);
        Quaternion targetRotation = Quaternion.LookRotation(targetpos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationspeed);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.Log("haikai");
    }*/
    void chase()
    {
        Quaternion playerRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, Time.deltaTime * rotationspeed * 10f);
        transform.Translate(Vector3.forward * speed * 3f * Time.deltaTime);
        Debug.Log("chase");
    }
    void attack()
    {
        Debug.Log("attack");
    }
    void Start()
    {
        targetpos = GetRandomPosition(transform.position);
    }
    void Update()
    {
        targetdistance = Vector3.SqrMagnitude(transform.position - targetpos);
        distancetoplayer = Vector3.SqrMagnitude(transform.position - player.transform.position);
       // if (distancetoplayer > 50f) haikai();
        /*else*/ if (3f < distancetoplayer && distancetoplayer < 50f) chase();
       // else attack();
    }
}
