using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;


public class Purchase : MonoBehaviour
{
    public Item thisItem;
    public ShopItem shopItem;
    public Inventory MyBag;
    public ShopInventory ShopBag;

    public int MaxNum;
    public int HaveNum;
    public int PurchaseNum;

    public Text PurNumText;
    public Text BagNumText;
    public Text RemainNumText;
    void Start()
    {
        PurNumText = GetComponent<Text>();
        BagNumText = GetComponent<Text>();
        RemainNumText= GetComponent<Text>();
    }
    void Update()
    {
        PurNumText.text = PurchaseNum+" ";
        if (thisItem.itemNumber > 999)
        {
            BagNumText.text = "已有"+thisItem.itemNumber + "999+";

        }
        else
        {
            BagNumText.text = "已有" + thisItem.itemNumber + " ";
        }
        RemainNumText.text = " "+HaveNum+" ";

    }
    public void PurchaseNumPlus()
    {
        if (PurchaseNum < HaveNum)
            PurchaseNum++;
        else 
            PurchaseNum = HaveNum ;
    }
    public void PurchaseNumMax()
    {
        PurchaseNum = HaveNum;
    }
    public void PurchaseNumMin()
    {
        PurchaseNum=1 ;
    }
    public void PurchaseNumDpwn()
    {
        if( PurchaseNum>1)
            PurchaseNum--;
        else
            PurchaseNum = 1 ;
    }
}
