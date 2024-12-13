using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    [SerializeField]
    private InventoryView _inventoryView;

    [SerializeField]
    private GameObject _slotViewPrefab;

    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<InventoryPresenter>()
            .AsSingle()
            .WithArguments(new Inventory(10), _inventoryView, _slotViewPrefab)
            .NonLazy();
    }
}