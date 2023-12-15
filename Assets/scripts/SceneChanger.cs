using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public int sceneNumber;

    public void NextLevel()
    {
        SceneManager.UnloadSceneAsync(sceneNumber);
        sceneNumber++;
        SceneManager.LoadScene(sceneNumber, LoadSceneMode.Additive);
    }
    
    

    public void Exit()
    {
        
    }
}
