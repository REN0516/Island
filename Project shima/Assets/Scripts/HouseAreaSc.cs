using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseAreaSc : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "HouseArea")
        {
            SceneManager.LoadScene("House");
        }
    }


}
