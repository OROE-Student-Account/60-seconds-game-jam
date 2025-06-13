using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void Exit()
    {
        Application.Quit();
    }

    public static int SceneCount()
    {
        return SceneManager.sceneCountInBuildSettings;
    }
}