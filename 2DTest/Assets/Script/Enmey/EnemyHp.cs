using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{

    public Slider EnemyHPUIShow;
    public Enemy Enemy;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHPUIShow.value = -Enemy.EnemyInfo.EnemyHP / 100 + 1 ;
    }

}
