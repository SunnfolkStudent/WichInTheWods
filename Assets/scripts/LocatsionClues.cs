using UnityEngine;
using UnityEngine.Playables;

public class LocatsionClues : MonoBehaviour, Interactable
{
    private PlayableDirector _playableDirector;
    public SolsticeControler solsticeControler;

    public GameObject canvas;

    private void Start()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }

    public void Interact()
    {
       _playableDirector.Play();
    }

    public void NextLevel()
    {
        solsticeControler = GameObject.Find("SolsticeControler").GetComponent<SolsticeControler>();
        solsticeControler.GoToNextLevel();
        canvas.SetActive(false);
    }

    public void Stay()
    {
        canvas.SetActive(false);
    }
    
}

