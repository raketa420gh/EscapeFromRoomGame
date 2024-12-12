using UnityEngine;
using Zenject;

public class InventoryView : MonoBehaviour
{
    [SerializeField] 
    private GameObject _slotViewPrefab;
    
    private Inventory _inventory;

    [Inject]
    public void Construct(Inventory inventory)
    {
        _inventory = inventory;
    }

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