using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    private Button[] _buttons; // Array to store all the buttons

    private int _currentButtonIndex = 0; // Index of the currently selected button

    private void Start()
    {
        // Ensure buttons array is populated with the buttons you want to navigate
        _buttons = new Button[ButtonContainer.Instance.buttonList.Count];
        for (int i = 0; i < ButtonContainer.Instance.buttonList.Count; i++)
        {
            _buttons[i] = ButtonContainer.Instance.buttonList[i].GetComponent<Button>();
        }

        // Highlight the default selected button
        HighlightButton(_currentButtonIndex);
    }

    private void Update()
    {
        if (NpcSpeaker.CurrentSpeaker.waitingForResponse == true)
        {
            // Keyboard input to navigate through buttons
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveToPreviousButton();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveToNextButton();
            }
            else if (Input.GetKeyDown(KeyCode.Return)) // Enter key to select the current button
            {
                SelectButton(_currentButtonIndex);
            }
        }
    }

    private void MoveToPreviousButton()
    {
        // Move to the previous button in the array
        _currentButtonIndex = (_currentButtonIndex - 1 + _buttons.Length) % _buttons.Length;
        HighlightButton(_currentButtonIndex);
    }

    private void MoveToNextButton()
    {
        // Move to the next button in the array
        _currentButtonIndex = (_currentButtonIndex + 1) % _buttons.Length;
        HighlightButton(_currentButtonIndex);
    }

    private void HighlightButton(int index)
    {
        // Unhighlight all buttons
        foreach (Button button in _buttons)
        {
            ColorBlock colors = button.colors;
            colors.normalColor = Color.white; // Change this color to suit your needs
            button.colors = colors;
        }

        // Highlight the selected button
        ColorBlock selectedColors = _buttons[index].colors;
        selectedColors.normalColor = Color.yellow; // Change this color to suit your needs
        _buttons[index].colors = selectedColors;
    }

    private void SelectButton(int index)
    {
        // Perform the action associated with the selected button
        _buttons[index].onClick.Invoke();
    }
}
