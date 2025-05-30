using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class KilledManage : MonoBehaviour
{
    public int TotalNum;
    public int KilledNum;

    private Text text;
    void Start()
    {
        KilledNum = 0;
        TotalNum = 3;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = KilledNum.ToString()+"/"+TotalNum.ToString();
    }

}
