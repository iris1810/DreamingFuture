using UnityEngine;

public class KeypadInteract : MonoBehaviour
{
    public KeypadUI keypadUI;

    void Grab()
    {
        Debug.Log("Keypad clicked!");

        if (keypadUI != null)
        {
            keypadUI.OpenPanel();
        }
        else
        {
            Debug.Log("KeypadUI NOT assigned!");
        }
    }
}