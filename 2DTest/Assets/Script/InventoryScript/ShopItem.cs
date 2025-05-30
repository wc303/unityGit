using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ShopItem", menuName = "Inventory/New ShopItem")]
//[System.Serializable]
public class ShopItem : ScriptableObject
{
    public Item item;

    public string itemName ;//����
    public Sprite itemLevelImage;//��Ʒ�ȼ���Ӧ�ĵ�ͼ
    public Sprite itemImage;//��ƷͼƬ
    public int itemNumber;//��������
    [TextArea]
    public string itemInfo;//����
    public int itemLevel;//��Ʒ�ȼ�

    public int MaxNum;//�����
    public int PurchaseNum=1;//��������

}
