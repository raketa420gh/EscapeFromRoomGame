using System;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    private Inventory _inventory;

    private void OnEnable()
    {
        _inventory.OnInventoryStateChanged += HandleInventoryChangeStateEvent;
    }

    private void OnDisable()
    {
        _inventory.OnInventoryStateChanged -= HandleInventoryChangeStateEvent;
    }

    private void HandleInventoryChangeStateEvent()
    {
        
    }
}