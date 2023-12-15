using UnityEngine;
using UnityEngine.Playables;

public class ObjeckInteracteble : MonoBehaviour, Interactable
{
    public static bool gotClueThisLevel;
    public PlayableDirector playableDirector;
    public SolsticeControler solsticeControler;

    public SceneChanger sceneChanger;
    public void Interact()
    {
        if (!gotClueThisLevel)
        {
            print("interacted");
            Player.indexCount++;
            gotClueThisLevel = true;
            solsticeControler.SolsticChange();
            SolsticeControler.solIndex++;
            sceneChanger.NextLevel();
        }
        
    }
}
