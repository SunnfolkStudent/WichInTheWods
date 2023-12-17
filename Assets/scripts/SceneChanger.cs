using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }
    private int sceneNumber = 2;

    public  Transform playerTransform;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // Rest of your initialization code...
        }
        else
        {
            Destroy(gameObject); // Ensures there's only one instance
        }
        
    }


    public void NextLevel()
    {
        StartCoroutine(INextLevel());
    }

    public IEnumerator INextLevel()
    {
        yield return new WaitForSeconds(2);
        playerTransform.position = Vector3.zero; 
        SceneManager.LoadScene(sceneNumber+1, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(sceneNumber);
        sceneNumber++;
        yield break;
    }

    public void StartGame()
    {
        StartCoroutine(IStartGame());
    }
    
    public IEnumerator IStartGame()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Player");
        SceneManager.LoadScene("farm", LoadSceneMode.Additive);
        SceneManager.LoadScene("ChurchLeter", LoadSceneMode.Additive);
        yield break;
    }

    public void GoInHouse()
    {
  
    }
    
    
    public void Exit()
    {
        Application.Quit();
    }
}
