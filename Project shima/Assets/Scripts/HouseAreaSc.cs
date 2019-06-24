using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseAreaSc : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "HouseArea")
        {
            SceneManager.LoadScene("House");
            transform.position = new Vector3(0f, 0.6f, 0f);
        }
    }


}
