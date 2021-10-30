using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject Inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
    }
}

