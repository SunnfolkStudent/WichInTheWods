using UnityEngine;

public class ObjeckInteracteble : MonoBehaviour, Interaceble
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
