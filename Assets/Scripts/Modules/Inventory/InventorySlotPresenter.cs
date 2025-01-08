using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class InventorySlotPresenter
{
    public event Action<InventorySlotPresenter> OnSlotSelected;
    
    private InventorySlot _slot;
    private readonly InventorySlotView _slotView;
    
    public InventorySlotPresenter(InventorySlot slot, InventorySlotView slotView)
    {
        _slot = slot;
        _slotView = slotView;
    }

    public void Initialize()
    {
        _slotView.OnSlotButtonClicked += HandleSlotButtonClickEvent;
    }

    public void Dispose()
    {
        _slotView.OnSlotButtonClicked -= HandleSlotButtonClickEvent;
        
        if (_slotView == null)
            return;
        
        Object.Destroy(_slotView);
    }

    private void HandleSlotButtonClickEvent()
    {
        OnSlotSelected?.Invoke(this);
    }
}