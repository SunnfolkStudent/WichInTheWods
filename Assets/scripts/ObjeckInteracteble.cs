using UnityEngine;

public class ObjeckInteracteble : MonoBehaviour, Interactable
{
    public bool gotClueThisLevel;
    public void Interact()
    {
        if (!gotClueThisLevel)
        {
            print("interacted");
            Player.indexCount++;
        }
        
    }
}
