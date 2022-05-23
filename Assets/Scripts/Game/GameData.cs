using System;
using System.Collections.Generic;

public enum ItemType
{
    Factory,
    Upgrade
}

public enum BuildType
{
    UserInput,
    Hand,
    Human,
    Farm,
    Factory
}

[Serializable]
public class ShopItemTable
{
    public ItemType Type;
    public int TargetId;
    public string Name;
    public int Cost;
}

public class GameData
{
    static public List<ShopItemTable> ShopItemTable = new List<ShopItemTable>()
    {
        new ShopItemTable(){ Type = ItemType.Factory, TargetId = 1, Name = "カーソル", Cost = 10 },
        new ShopItemTable(){ Type = ItemType.Factory, TargetId = 2, Name = "人", Cost = 100 },
        new ShopItemTable(){ Type = ItemType.Factory, TargetId = 3, Name = "農場", Cost = 1000 },
        new ShopItemTable(){ Type = ItemType.Factory, TargetId = 4, Name = "工場", Cost = 10000 },
        new ShopItemTable(){ Type = ItemType.Upgrade, TargetId = 1, Name = "カーソル生産力2倍", Cost = 500 },
        new ShopItemTable(){ Type = ItemType.Upgrade, TargetId = 2, Name = "人の生産力2倍", Cost = 10000 },
        new ShopItemTable(){ Type = ItemType.Upgrade, TargetId = 3, Name = "全部生産力2倍", Cost = 100000 }
    };
}
