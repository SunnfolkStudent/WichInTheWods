using UnityEngine;
using UnityEngine.Playables;

public class Door : MonoBehaviour, Interactable
{
    private bool _isInHouse;

    public PlayableDirector director; 
    public void Interact()
    {
        if (!_isInHouse)
        {
            print("goInHouse");
            _isInHouse = true;
            director.Play();
        }
        else if(_isInHouse)
        {
            print("goOutOfHouse");
            _isInHouse = false;
        }
        
    }
}
