using System;
using UnityEngine;
using UnityEngine.Events;


public class LastLocatsionClue : MonoBehaviour, Interactable
{   
    private bool _hasInteracted;
    [Serializable] public class StartEvent : UnityEvent { }
    [SerializeField] private StartEvent startEvent = new StartEvent();
    public StartEvent OnStartEvent
    {
        get { return startEvent; }
        set { startEvent = value; }
    }

    public void Interact()
    {
        print("hasInteracted");
        startEvent.Invoke();
        if (!_hasInteracted)
        {
            Player.indexCount++;
            _hasInteracted = true;
        }
    } 
}
