using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class EnemyGenerated:MonoBehaviour
 {
        public float[] TimePoints;//生成敌人的时间点
        public float GameTime;

    public GameObject EnemyPositions; // 拖入路径点

    public GameObject EnemyObj;

    public bool level1;
    public bool level2;
    public bool level3;

    private void Start()
        {
        level1 = false;
        level2 = false;
        level3 = false;


        TimePoints = new float[3];
            TimePoints[0] = 5f;
            TimePoints[1] = 10f;
            TimePoints[2] = 15f;

        EnemyInfo enemyInfo = new EnemyInfo();

        //EnemyObj = (GameObject)Resources.Load("Enemy");

        }

        void EnemyTime()
        {
            if (GameTime > TimePoints[0] && GameTime < TimePoints[1])
            {
                if(level1 == false){
                EnemyGenerate(1);
                level1 = true;
                }

            }
            if(GameTime >TimePoints[1]&& GameTime < TimePoints[2])
            {
                if (level2 == false)
                {
                   EnemyGenerate(1);
                    level2 = true;
                }
            }
            if (GameTime > TimePoints[2])
            {
                if (level3 == false)
                {
                    EnemyGenerate(1);
                    level3 = true;
                }
        }
        }
    private void Update()
    {
        GameTime += Time.deltaTime;
        EnemyTime();
    }
    void EnemyGenerate(int number)
    {
        for(int i=0;i<number;i++)
        {
            //int temp = Random.Range(0, 4);
            if (EnemyObj != null)
                Instantiate(EnemyObj, EnemyPositions.transform.position, this.gameObject.transform.rotation);
            else
                Debug.Log("No enemyObj!");
            //Instantiate(EnemyObj, EnemyPositins);
            //Instantiate(EnemyObj,EnemyPositions);
            //Debug.Log("enemy is created at "+EnemyObj.transform.position);
        }
    
    
    
    }



}

