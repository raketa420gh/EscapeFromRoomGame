using System;
public class InventorySlot
{
    public bool IsEmpty => _slotItem == null;
    public InventoryItem Item => _slotItem;

    private InventoryItem _slotItem = null;

    public InventorySlot(InventoryItem item = null)
    {
        _slotItem = item;
    }

    public bool AddItem(InventoryItem item)
    {
        if (item == null)
            throw new NullReferenceException();

        if (_slotItem != null)
            return false;

        _slotItem = item;
        return true;
    }

    public bool RemoveItem()
    {
        if (_slotItem != null)
        {
            _slotItem = null;
            return true;
        }

        return false;
    }
}