using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Vector3[] wayPoints = new Vector3[3];//徘徊するポイントの座標を代入するVector3型の変数を配列で作る
    private int currentRoot;//現在目指すポイントを代入する変数
    private int Mode;//敵の行動パターンを分けるための変数
    public Transform player;//プレイヤーの位置を取得するための変数
    public Transform enemypos;//敵の位置を取得するための変数
    private NavMeshAgent agent;//NaveMashAgentの情報を取得するための変数

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();//NaveMeshAgentを代入
    }

    void Update()
    {
        Vector3 pos = wayPoints[currentRoot];//Vector3型のposに現在の目的地の座標を代入
        float distance = Vector3.Distance(enemypos.position, player.transform.position);//敵とプレイヤーの距離を求める

        if (distance > 7)//プレイヤーとの位置が5以上なら
        {
            Mode = 0;
        }
        if (distance < 7)//プレイヤーとの距離が5以下なら
        {
            Mode = 1;
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
                agent.destination = player.transform.position;//プレイヤーに向かって進む
                break;
        }
    }
}
