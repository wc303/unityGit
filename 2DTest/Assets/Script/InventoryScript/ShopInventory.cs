using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ShopInventory", menuName = "Inventory/New ShopInventory")]
public class ShopInventory : ScriptableObject
{
    public List<ShopItem> itemList = new List<ShopItem>();
}