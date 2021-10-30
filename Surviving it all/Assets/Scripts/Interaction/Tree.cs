using UnityEngine;

public class Tree : InteractableObject
{
    [SerializeField] private Item item;
    [SerializeField] private PlayerInventory playerInventory;
    public override void Interact()
    {
        Debug.Log("Interacting with" + this.name);
        playerInventory = FindObjectOfType<PlayerInventory>();
        playerInventory.Inventory.GetComponent<Inventory>().AddItem(item);
    }

    public override string GetInteractionInstruction()
    {
        return "Press <color=green>E</color> to cut tree";
    }
}
