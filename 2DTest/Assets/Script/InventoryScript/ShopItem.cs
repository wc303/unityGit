using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ShopItem", menuName = "Inventory/New ShopItem")]
//[System.Serializable]
public class ShopItem : ScriptableObject
{
    public Item item;

    public string itemName ;//名称
    public Sprite itemLevelImage;//物品等级对应的底图
    public Sprite itemImage;//物品图片
    public int itemNumber;//持有数量
    [TextArea]
    public string itemInfo;//描述
    public int itemLevel;//物品等级

    public int MaxNum;//最大库存
    public int PurchaseNum=1;//购买数量

}
