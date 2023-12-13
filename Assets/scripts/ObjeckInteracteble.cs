using UnityEngine;

public class ObjeckInteracteble : MonoBehaviour, Interaceble
{
    public void Interact()
    {
        print("interacted");
        Player.indexCount++;
    }
}
