using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField]
    private InventoryView _inventoryView;
    
    [SerializeField]
    private InventorySlotPresenter _slotPresenterPrefab;

    [SerializeField]
    private int _capacity = 10;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<InventoryPresenter>()
            .AsSingle()
            .WithArguments(new Inventory(_capacity), _inventoryView, _slotPresenterPrefab)
            .NonLazy();
    }
}