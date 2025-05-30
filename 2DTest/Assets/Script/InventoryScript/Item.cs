using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Item",menuName ="Inventory/New Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public string itemName;//����
    public  Sprite itemLevelImage;//��Ʒ�ȼ���Ӧ�ĵ�ͼ
    public Sprite itemImage;//��ƷͼƬ
    public int itemNumber;//��������
    public int itemID;
    [TextArea]
    public  string itemInfo;//����
    public int itemLevel;//��Ʒ�ȼ�

    //public string itemName;//����
    //public Sprite itemLevelImage;//��Ʒ�ȼ���Ӧ�ĵ�ͼ
    //public Sprite itemImage;//��ƷͼƬ
    //public int itemNumber;//��������
    //[TextArea]
    //public string itemInfo;//����
    //public int itemLevel;//��Ʒ�ȼ�
    public itemKind itemkind;

}
public enum itemKind
{
    Consume,
    Basic,
    Cultivate
}