using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    public int sceneNumber;

    public void NextLevel()
    {
        SceneManager.LoadScene(sceneNumber+1, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(sceneBuildIndex:sceneNumber);
        sceneNumber++;
       
    }
    
    
    public void Exit()
    {
        
    }
}
