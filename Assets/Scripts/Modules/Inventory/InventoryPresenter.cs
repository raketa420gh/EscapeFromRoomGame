using System;
using Zenject;

public class InventoryPresenter : IInitializable, IDisposable
{
    private readonly Inventory _inventory;
    private readonly InventoryView _inventoryView;

    public InventoryPresenter(Inventory inventory, InventoryView inventoryView)
    {
        _inventory = inventory;
        _inventoryView = inventoryView;
    }

    void IInitializable.Initialize()
    {
        _inventory.OnInventoryStateChanged += HandleInventoryStateChangeEvent;
        _inventoryView.OnSlotClicked += HandleInventoryViewSlotClickEvent;
    }

    void IDisposable.Dispose()
    {
        _inventory.OnInventoryStateChanged -= HandleInventoryStateChangeEvent;
        _inventoryView.OnSlotClicked -= HandleInventoryViewSlotClickEvent;
    }

    private void UpdateInventoryView()
    {
        
    }

    private void HandleInventoryStateChangeEvent()
    {
        UpdateInventoryView();
    }

    private void HandleInventoryViewSlotClickEvent(InventorySlot slot)
    {
        
    }
}