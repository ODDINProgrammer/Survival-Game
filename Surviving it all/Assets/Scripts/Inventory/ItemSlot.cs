using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI amountText;

    private Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }

    private int _amount;
    public int Amount
    {
        get { return _amount; }
        set
        {
            _amount = value;
            amountText.enabled = _item != null && _amount > 1 && _item.MaxStacks > 1;
            if (amountText.enabled)
            {
                amountText.SetText(_amount.ToString());
            }
        }
    }

    private void OnValidate()
    {
        if (amountText == null)
            amountText = GetComponentInChildren<TextMeshProUGUI>();
    }
}
