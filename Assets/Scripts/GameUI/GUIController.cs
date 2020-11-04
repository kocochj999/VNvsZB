using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{
    public void GetHostingScence()
    {
        SceneManager.LoadScene("HostingGame");
    }
}
