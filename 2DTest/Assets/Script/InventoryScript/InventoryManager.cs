using UnityEngine;
using System.Collections.Generic;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    // �洢������Ʒ���ݵ��ֵ�
    public Dictionary<int, Item> itemDictionary;

    public void Start()
    {
        // ��ʼ���ֵ�
        itemDictionary = new Dictionary<int, Item>();

        // �������ж����Ʒ����
        Item[] allItems = Resources.LoadAll<Item>("Items");

        // ����Ʒ������ӵ��ֵ���
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

        // �����ض���Ʒ����Ϣ
        Item specificItem = FindItemByID(1); // ������Ҫ����IDΪ1����Ʒ
        if (specificItem != null)
        {
            Debug.Log("Item Name: " + specificItem.itemName);
            Debug.Log("Item Quantity: " + specificItem.itemNumber);
            // ��������...
        }
    }

    // ͨ��ID������Ʒ
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