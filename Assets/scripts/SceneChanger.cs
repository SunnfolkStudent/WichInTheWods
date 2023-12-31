using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }
    private int sceneNumber = 1;

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

    public void NextLevelFromHouse()
    {
        StartCoroutine(INextLevelFromHouse());
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

    public IEnumerator INextLevelFromHouse()
    {
        yield return new WaitForSeconds(2);
        playerTransform.position = Vector3.zero; 
        SceneManager.LoadScene(sceneNumber+1, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("insideRom");
        sceneNumber++;
        yield break;
    }
    

    public void StartGame()
    {
        StartCoroutine(IStartGame());
    }
    
    public IEnumerator IStartGame()
    {
        SaveFileHandler.ResetSavegame();
        
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Player");
        SceneManager.LoadScene("farm", LoadSceneMode.Additive);
        SceneManager.LoadScene("ChurchLeter", LoadSceneMode.Additive);
        yield break;
    }

    public void GoodEnding()
    {
        
    }

    public void BadEnding()
    {
        
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("mainMenue");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
