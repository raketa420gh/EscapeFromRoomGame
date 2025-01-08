using System;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public event Action<InventorySlot> OnSlotClicked;
}