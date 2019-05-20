using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelectManager : MonoBehaviour
{
    public void PushPlayButton()
    {
        SceneManager.LoadScene("Main");
    }
}
