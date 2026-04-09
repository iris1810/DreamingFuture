using UnityEngine;

public class InventoryItem_Key : InventoryItem
{
    public DoorController door;

    public new void Grab()
    {
        if (door != null)
        {
            door.UnlockDoor();
            SoundManager1.Play(SoundType1.CORRECT);
        }
        else
        {
            Debug.Log("DoorController not assigned on key!");
        }

        gameObject.SetActive(false);
        Inventory.Instance.Add(this);
    }

    public override void Use()
    {
        // Không cần làm gì nữa
        // vì cửa đã unlock ngay khi nhặt key
    }
}