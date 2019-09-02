using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rule : MonoBehaviour
{
    public void PushGamePlayButton()
    {
        SceneManager.LoadScene("Version_α");
        //transform.position = new Vector3(1f, 1f, 1f);
    }



}
