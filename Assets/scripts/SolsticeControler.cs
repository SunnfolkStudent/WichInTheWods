using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SolsticeControler : MonoBehaviour
{
    public Sprite[] SolstisObjects;
    private int solIndex = 1;

    private PlayableDirector playableDirector;

    public Image solFirst, solSecond;

    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    } 

    public void SolsticChange()
    {
        solFirst.sprite = SolstisObjects[solIndex];
        solSecond.sprite = SolstisObjects[solIndex+1];
    }

    public void GoToNextLevel()
    {
        playableDirector.Play();
        Player.indexCount++;
        solIndex++;
        print("solIndex");
        SceneChanger.Instance.NextLevel();
        
    }
    public void GoToNextLevelFromHousee()
    {
        playableDirector.Play();
        Player.indexCount++;
        solIndex++;
        print("solIndex");
        SceneChanger.Instance.NextLevelFromHouse();
        
    }
}
