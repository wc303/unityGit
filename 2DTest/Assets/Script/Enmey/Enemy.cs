using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public EnemyInfo EnemyInfo;
    public EnemyLogic EnemyLogic;//获取enemy的基本信息

    public Agent agent;//攻击或阻挡的对象

    //public AudioSource AudioSource1;
    //public AudioSource AudioSource2;
    //public AudioSource AudioSource3;
    //public AudioSource AudioSource4;
    public KilledManage killedManage;
    private bool alive;

    void Start()//基础数值初始化
    {
        EnemyInfo = new EnemyInfo();
        EnemyLogic=new EnemyLogic();

        EnemyLogic.enemyInfo = EnemyInfo;
        EnemyLogic.EnemyObj=EnemyInfo.EnemyObj=this.gameObject;
        EnemyLogic.enemy = GetComponent<Enemy>();

        //EnemyLogic.AudioSource1 = AudioSource1;
        //EnemyLogic.AudioSource2 = AudioSource2;
        //EnemyLogic.AudioSource3 = AudioSource3;
        //EnemyLogic.AudioSource4 = AudioSource4;

        EnemyLogic.enemyState = EnemyState.Move;
        EnemyInfo.EnemyMaxHP = 100;
        EnemyInfo.EnemyHP = 100;
        EnemyInfo.EnemyATK = 10;
        EnemyInfo.EnemyATKSpeed = 2f;
        EnemyInfo.EnemyMoveSpeed = 1f;

        killedManage = FindAnyObjectByType<KilledManage>();
        alive = true;

        Debug.Log("数值自定义完成");
    }

    void Update()
    {
        EnemyLogic.EnemyStateControl();//状态控制
        if (EnemyInfo.EnemyHP <= 0)
        {
            if (killedManage != null&&alive==true)
            {
                killedManage.KilledNum++;
                alive = false;
            }
            EnemyLogic.enemyState=EnemyState.Death;

        }
    }
}
