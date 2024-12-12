using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
    
    [SerializeField]
    private string _name;
    
    [SerializeField]
    private string _description;
    
    [SerializeField]
    private Sprite _icon;

    public InventoryItem(string name, string description = "", Sprite icon = null)
    {
        _name = name;
        _description = description;
        _icon = icon;
    }
}