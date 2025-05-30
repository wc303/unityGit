using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AgentState
{
    Idle,//待机
    Attack,//攻击
    Death//死亡
}
[System.Serializable]
public class AgentLogic
{
    public AgentState agentState;
    public Enemy enemy;
    public Agent agent;
    public GameObject AgentObj;
    public GameObject EnemyObj;
    public float attackBuffer;
    public AgentAttackTrigger trigger;

    public Queue<Enemy> ResistedQueue;//干员的阻挡队列

    //public AgentAttackTrigger agentAttackTrigger;

    public void Start()
    {

        //enemy = EnemyObj.GetComponent<Enemy>();
        //agent = AgentObj.GetComponent<Agent>();
        //trigger=AgentObj.GetComponentInChildren<AgentAttackTrigger>();
        attackBuffer = agent.AgentInfo.AgentATKInterval - agent.AgentInfo.AgentATKSpeed / 100 + 1;
    }
    public void AgentStateControl()
    {
        switch (agentState)
        {
            case AgentState.Idle:
                AgentIdle();break;
            case AgentState.Attack:
                AgentAttack();break;
            case AgentState.Death:
                AgentDeath();break;
        }
    }
    public void AgentIdle()//待机
    {
        //随机播放语音或动作
    }
    public void AgentAttack()//攻击
    {
                if (ResistedQueue.Count != 0)
                {
                    enemy = ResistedQueue.Peek();
                }
                //enemy = EnemyObj.GetComponent<Enemy>();
                attackBuffer -= Time.deltaTime;
                if (attackBuffer <= 0)//攻击逻辑
                {
                    agentAttack();
                    attackBuffer = agent.AgentInfo.AgentATKInterval - agent.AgentInfo.AgentATKSpeed / 100 + 1;
                }

                if(enemy==null)
                {
                    
                    if (ResistedQueue.Count != 0)
                    {
                        ResistedQueue.Dequeue();
                        enemy = ResistedQueue.Peek();
                        AgentAttack();
                    }

                    else
                    {
                        enemy = null;
                        Debug.Log("无EnemyObj");
                        agentState = AgentState.Idle;
                    }

                }
    }
    public void AgentDeath() //撤退
    { 
        GameObject.Destroy(AgentObj);
    }
    public void agentAttack()
    {
        int dmg = 0;

        if (agent.AgentInfo.AgentATKType == AgentATKType.physics)
        {
            dmg = (int)((agent.AgentInfo.AgentATK - agent.AgentInfo.AgentDFE) * (1 - enemy.EnemyInfo.EnemyDamageReduction));
            if (dmg <= 0)
            { dmg = 1; }
           

        }
        else if (agent.AgentInfo.AgentATKType == AgentATKType.spell)
        {
            dmg= (int)((agent.AgentInfo.AgentATK * (1 - enemy.EnemyInfo.EnemySpellDFE)) * (1 - enemy.EnemyInfo.EnemyDamageReduction));
        }
        enemy.EnemyInfo.EnemyHP -= dmg;
    }
}
