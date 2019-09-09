using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public Vector3[] wayPoints = new Vector3[3];//徘徊するポイントの座標を代入するVector3型の変数を配列で作る
    private int currentRoot;//現在目指すポイントを代入する変数
    private int Mode;//敵の行動パターンを分けるための変数
    public GameObject player;//プレイヤーの位置を取得するための変数
    public Transform enemypos;//敵の位置を取得するための変数
    private NavMeshAgent agent;//NaveMashAgentの情報を取得するための変数
    GameObject HeartBeatColor;
    private float heartbeat;
    private float DecayTime;
    private float BeatTime;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//NaveMeshAgentを代入
        player = PlayerMove.GetPlayer();
        HeartBeatColor = GameObject.Find(" Heartbeat");
        anim = GetComponent<Animator>();
        //targetpos = GetRandomPosition(transform.position);
    }

    void Update()
    {
        Vector3 pos = wayPoints[currentRoot];//Vector3型のposに現在の目的地の座標を代入
        float distance = Vector3.Distance(enemypos.position, player.transform.position);//敵とプレイヤーの距離を求める
        BeatTime = 100;
        DecayTime = Time.deltaTime * BeatTime;
        heartbeat -= DecayTime;

        HeartBeatColor.GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, heartbeat / 255.0f);

/*        if (heartbeat <= 0.0f)
        {
            heartbeat = 100.0f;
        }*/

        if (distance >= 25)//プレイヤーとの位置が15以上なら
        {
            anim.SetBool("Run", false);
            Mode = 0;

            if (heartbeat <= 0.0f)
            {
                heartbeat = 100.0f;
                BeatTime = 200f;
            }
        }
        if (distance < 25)//プレイヤーとの距離が15以下なら
        {
            Mode = 1;
            if (heartbeat <= 150.0f)
            {
                heartbeat = 200.0f;
                BeatTime = 400f;
            }
        }
        if (distance <= 3)
        {
            Mode = 2;
        }
        switch (Mode)//Modeの切り替え
        {
            case 0://case0の場合

                if (Vector3.Distance(transform.position, pos) < 1f)//Enemyの位置と現在の目的地との距離が1以下なら
                {
                    currentRoot += 1;
                    if (currentRoot > wayPoints . Length - 1)//currentRootがwayPointsの要素数より-1大きければ
                    {
                        currentRoot = 0;
                    }
                }
                GetComponent<NavMeshAgent>().SetDestination(pos);//NaveMeshAgentの情報を取得し目的地をposにする
                break;

            case 1:
                anim.SetBool("Run", true);
                agent.destination = player.transform.position;//プレイヤーに向かって進む
                agent.speed = 13.0f;
                break;

            case 2:
                GetComponent<NavMeshAgent>().isStopped = true;

                anim.SetBool("Run", false);

                SceneManager.LoadScene("GameOver");

                break;
        }
    }
}
