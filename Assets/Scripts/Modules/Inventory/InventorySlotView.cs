using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField]
    private Button _slotButton;

    [SerializeField]
    private Image _itemImage;

    [SerializeField]
    private TMP_Text _itemNameText;

    public void SetSlotItem(InventoryItem item)
    {
        if (!_itemImage.GameObject().gameObject.activeSelf)
        {
            EnableSlotItemView();

            _itemImage.sprite = item.Icon;
            _itemNameText.text = item.Name;
        }
    }

    public void ClearSlot()
    {
        if (_itemImage.GameObject().gameObject.activeSelf)
        {
            DisableSlotItemView();
        }
    }

    private void EnableSlotItemView()
    {
        _itemImage.GameObject().SetActive(true);
        _itemNameText.GameObject().SetActive(true);
        _slotButton.interactable = true;
    }

    private void DisableSlotItemView()
    {
        _itemImage.GameObject().SetActive(false);
        _itemNameText.GameObject().SetActive(false);
        _slotButton.interactable = false;
    }
}