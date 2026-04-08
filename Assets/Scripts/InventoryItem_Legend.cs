using UnityEngine;

public class InventoryItem_Legend : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string message;

    public void Interact()
    {
        Debug.Log(message);
    }
}
