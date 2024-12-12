using UnityEngine;

public class InventoryItem
{
    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;
    
    private readonly string _name;
    private readonly string _description;
    private readonly Sprite _icon;

    public InventoryItem(string name, string description, Sprite icon)
    {
        _name = name;
        _description = description;
        _icon = icon;
    }
}