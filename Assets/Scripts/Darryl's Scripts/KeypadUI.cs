using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.InputSystem;



public class KeypadUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField inputField;
    public TMP_Text feedbackText;
    public DoorController door;

    public string correctCode = "HELLO WORLD";

    public enum KeypadState { Idle, Active, Correct, Incorrect }
    public KeypadState currentState = KeypadState.Idle;

    // public void OpenPanel()
    // {
    //     panel.SetActive(true);
    //     inputField.text = "";
    //     feedbackText.text = "";

    //     Cursor.lockState = CursorLockMode.None;
    //     Cursor.visible = true;

    //     inputField.ActivateInputField();
    // }

    public void OpenPanel()
    {
        currentState = KeypadState.Active;

        panel.SetActive(true);
        inputField.text = "";
        feedbackText.text = "";

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        inputField.ActivateInputField();
        FindFirstObjectByType<FirstPersonController>().enabled = false;
    }

    public void ClosePanel()
    {
        panel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindFirstObjectByType<FirstPersonController>().enabled = true;
    }

    // public void SubmitCode()
    // {
    //     string input = inputField.text.ToUpper();

    //     if (input == correctCode)
    // {
    //     feedbackText.text = "ACCESS GRANTED";

    //     if (door != null)
    //     {
    //         door.SetActive(false);
    //     }
    //     else
    //     {
    //         Debug.Log("Door not assigned!");
    //     }
    // }

    //     inputField.text = "";
    //     inputField.ActivateInputField();
    // }

    public void SubmitCode()
    {
        string input = inputField.text.ToUpper();

        if (input == correctCode)
        {
            currentState = KeypadState.Correct;
            feedbackText.text = "ACCESS GRANTED";

            if (door != null)
        {
            door.UnlockDoor();
            SoundManager1.Play(SoundType1.CORRECT); 
        }
        }
        else
        {
            currentState = KeypadState.Incorrect;
            feedbackText.text = "INVALID CODE";
        }

        inputField.text = "";
        inputField.ActivateInputField();
    }

    void Update()
{
    if (panel.activeSelf && Keyboard.current.escapeKey.wasPressedThisFrame)
    {
        ClosePanel();
    }
}
}