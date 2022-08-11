using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextSceneIndex <= SceneManager.sceneCount)
        {
            SceneManager.LoadScene(nextSceneIndex);
        } 
        else
        {
            SceneManager.LoadScene(1);
        }
        
    }
}
