using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void ChangeScene(string Name)
    {
        SceneManager.LoadScene(Name);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
