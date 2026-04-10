using UnityEngine;

public class KeypadInteract : MonoBehaviour
{
    public KeypadUI keypadUI;

    void Grab()
    {
        Debug.Log("Keypad clicked!");
        SoundManager1.Play(SoundType1.CLICK_ON);

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