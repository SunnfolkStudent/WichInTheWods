using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameObject = UnityEngine.GameObject;

public class DialogueBoxManager : MonoBehaviour
{
    public static DialogueBoxManager Instance { get; private set; }
    
    private List<GameObject> dialogueUI = new List<GameObject>();
    public Image portraitNpcImage;
    public Image playerImage;
    public Sprite playerSprite;
    public TextMeshProUGUI nameTextBox;
    public TextMeshProUGUI DialogueBox;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // Rest of your initialization code...
        }
        else
        {
            Destroy(gameObject); // Ensures there's only one instance
        }
    }

    private void Start()
    {
        
        
        GameObject[] UIObjects = GameObject.FindGameObjectsWithTag("DialogueUI");
        dialogueUI.AddRange(UIObjects);
        
        HideDialogueContainers();
    }

    public void ShowDialogueContainers(Sprite npcPortrait)
    {
        foreach (GameObject UIElement in dialogueUI)
        {
            UIElement.SetActive(true);
        }

        nameTextBox.text = NpcSpeaker.CurrentSpeaker.npc.npcName;
        portraitNpcImage.sprite = npcPortrait;
        playerImage.sprite = playerSprite;
        

        float aspectRatio = portraitNpcImage.sprite.rect.height / portraitNpcImage.sprite.rect.width;

        // Set the height to maintain aspect ratio while changing width
        portraitNpcImage.rectTransform.sizeDelta = new Vector2(portraitNpcImage.rectTransform.sizeDelta.y / aspectRatio, portraitNpcImage.rectTransform.sizeDelta.y);
        
        float aspectRatioPlayer = playerImage.sprite.rect.height / playerImage.sprite.rect.width;

        // Set the height to maintain aspect ratio while changing width
        playerImage.rectTransform.sizeDelta = new Vector2(playerImage.rectTransform.sizeDelta.y / aspectRatioPlayer, playerImage.rectTransform.sizeDelta.y);
    }

    public void HideDialogueContainers()
    {
        foreach (GameObject UIElement in dialogueUI)
        {
            UIElement.SetActive(false);
        }
    }
}
