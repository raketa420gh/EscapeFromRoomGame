using System;
using System.Collections.Generic;
using ModestTree;

public class Inventory
{
    public InventorySlot[] Slots => _slots.ToArray();

    public event Action OnInventoryStateChanged;
    
    private readonly List<InventorySlot> _slots = new();

    public Inventory(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException();

        for (int i = 0; i < capacity; i++)
        {
            InventorySlot newSlot = new();
            _slots.Add(newSlot);
        }
    }

    public bool AddItem(InventoryItem item)
    {
        if (item == null)
            throw new NullReferenceException();

        InventorySlot freeSlot = GetFreeSlot();

        if (freeSlot != null)
        {
            bool isItemAdded = freeSlot.AddItem(item);
            
            if (isItemAdded)
                OnInventoryStateChanged?.Invoke();

            return isItemAdded;
        }
        
        throw new NullReferenceException();
    }

    public bool RemoveItem(InventoryItem item)
    {
        if (item == null)
            throw new NullReferenceException();

        if (_slots.IsEmpty())
            return false;

        InventorySlot slotWithItem = GetItemSlot(item);

        if (slotWithItem != null)
        {
            bool isItemRemoved = slotWithItem.RemoveItem();
            
            if (isItemRemoved)
                OnInventoryStateChanged?.Invoke();

            return isItemRemoved;
        }
        
        throw new NullReferenceException();
    }

    private InventorySlot GetItemSlot(InventoryItem item)
    {
        InventorySlot slotWithItem = null;

        foreach (InventorySlot slot in _slots)
        {
            if (slot.Item == item)
                slotWithItem = slot;
        }

        return slotWithItem;
    }
    
    private InventorySlot GetFreeSlot()
    {
        if (_slots.IsEmpty())
            return null;

        foreach (var slot in _slots)
        {
            if (slot.IsEmpty)
                return slot;
        }

        return null;
    }
}