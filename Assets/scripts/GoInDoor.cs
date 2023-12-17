using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, Interactable
{
    private static bool _isInHouse;

    
    public void Interact()
    {
        if (SceneManager.GetActiveScene().name == "insideRom")
        {
            _isInHouse = true;
        }
        else
        {
            _isInHouse = false;
        }
        if (!_isInHouse)
        {
            SceneManager.LoadScene("insideRom",LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("vilige 1");
            _isInHouse = true;
        }
        else if(_isInHouse)
        {
            SceneManager.LoadScene("vilige 1",LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("insideRom");
            _isInHouse = false;
        }
        
    }
}
