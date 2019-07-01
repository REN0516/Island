using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove scPlayerMove;

    private Animator animator;
    private bool jcs;
    float inputHorizontal;
    float inputVertical;
    public float moveSpeed = 3f;
    Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

        jcs = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Playerの動き
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        //Playerのrunアニメーション
        if (jcs==false)
        {
            if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
            {
                animator.SetBool("run", true);
            }
            else
            {
                animator.SetBool("run", false);
            }
        }

        //しゃがみ歩きのアニメーション
        if (jcs == true)
        {
            moveSpeed = 0.5f;
            if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
            {
                animator.SetBool("crouchedWalking", true);
            }
            else
            {
                animator.SetBool("crouchedWalking", false);
            }

        }


        //しゃがみのアニメーション
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jcs == true)
            {
                animator.SetBool("crouch", false);
                jcs = false;

            }
            else
            {
                animator.SetBool("crouch", true);
                jcs = true;
                
            }
        }

        
       

    }
   private void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        playerRB.velocity = moveForward * moveSpeed + new Vector3(0, playerRB.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }


    void Awake()
    {
        //スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
        if (scPlayerMove == null)
        {
            DontDestroyOnLoad(gameObject);
            scPlayerMove = this;

        }
        //既にPlayerMoveスクリプトがあればこのシーンの同じゲームオブジェクトを削除

        else
        {
            Destroy(gameObject);
        }
    }
    public static GameObject GetPlayer()
    {
        return scPlayerMove.gameObject;
    }
}
