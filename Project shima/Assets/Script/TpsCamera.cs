using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsCamera : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float RotateSpeed;

    float yaw, pitch;

    // Start is called before the first frame update
    void Start()
    {

        RotateSpeed = 1;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Player.position.x, transform.position.y, Player.position.z);

        yaw += Input.GetAxis("Mouse X") * RotateSpeed; //横回転入力
        pitch -= Input.GetAxis("Mouse Y") * RotateSpeed; //縦回転入力

        pitch = Mathf.Clamp(pitch, -80, 60); //縦回転角度制限する

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); //回転の実行

    }
}
