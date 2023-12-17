using UnityEngine;
using UnityEngine.UI;

public class LocatsionClues : MonoBehaviour, Interactable
{
    public SolsticeControler solsticeControler;
    public void Interact()
    {
        solsticeControler = GameObject.Find("SolsticeControler").GetComponent<SolsticeControler>();
        solsticeControler.GoToNextLevel();
    }
    
}

