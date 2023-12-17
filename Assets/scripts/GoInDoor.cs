using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, Interactable
{
    private static bool _isInHouse;

    
    public void Interact()
    {
        if (!_isInHouse)
        {
            SceneManager.LoadScene("insideRom",LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("vilige1");
            _isInHouse = true;
        }
        else if(_isInHouse)
        {
            SceneManager.LoadScene("vilige 1");
            SceneManager.UnloadSceneAsync("insideRom");
            _isInHouse = false;
        }
        
    }
}
