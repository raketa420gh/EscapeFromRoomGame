using System;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] 
    private GameObject _slotViewPrefab;
    
    public event Action<InventorySlot> OnSlotClicked;
}