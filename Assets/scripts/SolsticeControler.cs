using UnityEngine;
using UnityEngine.UI;

public class SolsticeControler : MonoBehaviour
{
    public Sprite[] SolstisObjects;
    public int solIndex = 1;

    public Image solFirst, solSecond;

    public void SolsticChange()
    {
        solFirst.sprite = SolstisObjects[solIndex];
        solSecond.sprite = SolstisObjects[solIndex+1];
    }
    public void GoToNextLevel()
    {
        Player.indexCount++;
        solIndex++;
        SceneChanger.Instance.NextLevel();
    }
}
