using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneUseCase : IChangeSceneUseCase
{
    public void ChangeScene(int sceneIndex)
    {
        Debug.Log("change scene");
        SceneManager.LoadScene(sceneIndex);
    }
}
