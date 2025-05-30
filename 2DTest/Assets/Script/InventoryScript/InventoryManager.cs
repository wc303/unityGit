using UnityEngine;
using System.Collections.Generic;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    // 存储所有物品数据的字典
    public Dictionary<int, Item> itemDictionary;

    public void Start()
    {
        // 初始化字典
        itemDictionary = new Dictionary<int, Item>();

        // 假设你有多个物品数据
        Item[] allItems = Resources.LoadAll<Item>("Items");

        // 将物品数据添加到字典中
        foreach (Item item in allItems)
        {
            if (!itemDictionary.ContainsKey(item.itemID))
            {
                itemDictionary.Add(item.itemID, item);
                Debug.Log(item.itemName + " is in");
            }
            else
            {
                Debug.LogWarning("Duplicate item ID found: " + item.itemID);
            }
        }

        // 查找特定物品的信息
        Item specificItem = FindItemByID(1); // 假设你要查找ID为1的物品
        if (specificItem != null)
        {
            Debug.Log("Item Name: " + specificItem.itemName);
            Debug.Log("Item Quantity: " + specificItem.itemNumber);
            // 其他操作...
        }
    }

    // 通过ID查找物品
    public Item FindItemByID(int itemID)
    {
        if (itemDictionary.ContainsKey(itemID))
        {
            return itemDictionary[itemID];
        }
        Debug.LogWarning("Item with ID " + itemID + " not found.");
        return null;
    }
    
}