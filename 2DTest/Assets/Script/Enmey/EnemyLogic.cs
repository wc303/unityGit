using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.Audio;

//using static EnemyMovement;

[System.Serializable]
public enum EnemyState
{
    Idle,
    Move,
    Resisted,
    Attack,
    Death
}
[System.Serializable]
public class EnemyLogic 
{
    //public AudioSource AudioSource1;
    //public AudioSource AudioSource2;
    //public AudioSource AudioSource3;
    //public AudioSource AudioSource4;

    public Enemy enemy;
    public EnemyState enemyState;
    public EnemyInfo enemyInfo;

    public GameObject EnemyObj;
    public GameObject AgentObj;

    public Agent agent;
    //public Agent agent;
    bool IsMove=false;
    float IdleTime;

    float attackBuffer;
    public void EnemyStateControl()
    {
        //Debug.Log("开始检测");
;        switch (enemyState)
        {
            case EnemyState.Idle:
                EnemyIdle(); break;
            case EnemyState.Move:
                EnemyMove(); break;
            case EnemyState.Resisted:
                EnemyResisted();break;
            case EnemyState.Attack:
                EnemyAttack(); break;
            case EnemyState.Death:
                EnemyDeath(); break;
        }
    }
    public void EnemyIdle()
    {
        Debug.Log("Idle");
        //AudioSource1.Stop();
        //AudioSource2.Stop();
        enemyInfo.EnemyMoveSpeed = 0;
        IdleTime -= Time.deltaTime;
        if (IdleTime < 0f)
        {
            enemyState = EnemyState.Move;
            IsMove = false;
        }
    }
    public void EnemyMove()
    {
        //Debug.Log("Moving");

    }
    public void EnemyResisted()
    {
        Debug.Log("resisted");
        enemy.EnemyInfo.EnemyMoveSpeed=0;
        enemyState = EnemyState.Attack;
    }
   
    public void EnemyAttack()
    {
        //agent=AgentObj.GetComponent<Agent>();

        attackBuffer -=Time.deltaTime;
        if (attackBuffer <= 0)
        {
            //AgentObj.transform.parent.gameObject.GetComponent<Agent>().AgentInfo.AgentHP -= enemyInfo.EnemyATK;
            agent.AgentInfo.AgentHP-= enemyInfo.EnemyATK;
            attackBuffer = enemyInfo.EnemyATKSpeed;
        }
    }
    public void EnemyDeath()
    {
        //Debug.Log("there");
        
        agent.AgentInfo.AgentRemainResistNumber+=enemy.EnemyInfo.EnemyResistNumber;
        //Debug.Log("剩余阻挡中敌人数量：" + agent.AgentLogic.ResistedQueue.Count);
        GameObject.Destroy(EnemyObj);
        
    }
    public void enemyAttack()
    {
        int dmg = 0;

        if (enemy.EnemyInfo.EnemyATKType == EnemyATKType.physics)
        {
            dmg = (int)((enemy.EnemyInfo.EnemyATK - agent.AgentInfo.AgentDFE) * (1 - agent.AgentInfo.AgentDamageReduction));
            if (dmg <= 0)
            { dmg = 1; }
        }
        else if (enemy.EnemyInfo.EnemyATKType == EnemyATKType.spell)
        {
            dmg = (int)((enemy.EnemyInfo.EnemyATK * (1 - agent.AgentInfo.AgentDamageReduction)) * (1 - agent.AgentInfo.AgentSpellDFE));
        }
        agent.AgentInfo.AgentHP -= dmg;
    }
}
