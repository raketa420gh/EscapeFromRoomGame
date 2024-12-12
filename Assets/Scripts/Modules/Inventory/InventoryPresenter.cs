using System;
using UnityEngine;
using Zenject;

public class InventoryPresenter : IInitializable, IDisposable
{
    private readonly Inventory _inventory;
    private readonly InventoryView _inventoryView;
    private readonly GameObject _slotViewPrefab;

    public InventoryPresenter(Inventory inventory, InventoryView inventoryView, GameObject slotViewPrefab)
    {
        _inventory = inventory;
        _inventoryView = inventoryView;
        _slotViewPrefab = slotViewPrefab;
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