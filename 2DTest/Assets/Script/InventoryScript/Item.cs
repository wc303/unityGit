using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public string itemName;//名称
    public  Sprite itemLevelImage;//物品等级对应的底图
    public Sprite itemImage;//物品图片
    public int itemNumber;//持有数量
    public int itemID;
    [TextArea]
    public  string itemInfo;//描述
    public int itemLevel;//物品等级

    //public string itemName;//名称
    //public Sprite itemLevelImage;//物品等级对应的底图
    //public Sprite itemImage;//物品图片
    //public int itemNumber;//持有数量
    //[TextArea]
    //public string itemInfo;//描述
    //public int itemLevel;//物品等级
    public itemKind itemkind;

}
public enum itemKind
{
    Consume,
    Basic,
    Cultivate
}