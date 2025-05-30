using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostManage : MonoBehaviour
{
    float costSpeed;
    int startCost;
    float cost;
    int intCost;

    private Text text;
    void Start()
    {
        costSpeed = 1.0f;
        startCost = 0;
        cost = startCost;

        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        cost += Time.deltaTime * costSpeed;
        intCost = (int)cost;
        text.text=intCost.ToString();
    }
}
