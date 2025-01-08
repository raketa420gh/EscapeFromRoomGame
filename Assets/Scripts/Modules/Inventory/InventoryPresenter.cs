using System;
using System.Collections.Generic;
using Zenject;
using Object = UnityEngine.Object;

public class InventoryPresenter : IInitializable, IDisposable
{
    private readonly Inventory _inventory;
    private readonly InventoryView _inventoryView;
    private readonly InventorySlotView _slotViewPrefab;
    private readonly List<InventorySlotPresenter> _slotPresenters = new();

    public InventoryPresenter(Inventory inventory, InventoryView inventoryView, InventorySlotView slotViewPrefab)
    {
        _inventory = inventory;
        _inventoryView = inventoryView;
        _slotViewPrefab = slotViewPrefab;
    }

    void IInitializable.Initialize()
    {
        _inventory.OnInventoryStateChanged += HandleInventoryStateChangeEvent;
        _inventoryView.OnSlotClicked += HandleInventoryViewSlotClickEvent;

        if (_slotPresenters.Count > 0)
            return;
        
        _slotPresenters.Clear();
        
        foreach (InventorySlot slot in _inventory.Slots)
        {
            InventorySlotView slotView = Object.Instantiate(_slotViewPrefab);
            InventorySlotPresenter inventorySlotPresenter = new(slot, slotView);
            _slotPresenters.Add(inventorySlotPresenter);
        }
    }

    void IDisposable.Dispose()
    {
        _inventory.OnInventoryStateChanged -= HandleInventoryStateChangeEvent;
        _inventoryView.OnSlotClicked -= HandleInventoryViewSlotClickEvent;
        
        if (_slotPresenters.Count <= 0)
            return;

        foreach (InventorySlotPresenter presenter in _slotPresenters)
        {
            presenter.Dispose();
        }
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