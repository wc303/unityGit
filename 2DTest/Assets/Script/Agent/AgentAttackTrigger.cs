using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAttackTrigger : MonoBehaviour
{

   // public Enemy enemy;
    public Agent agent;
    public GameObject EnemyObj;
    private Enemy enemy;
    public GameObject AgentObj;
    public Transform parentTransform;

    //public AgentAttackTrigger agentAttackTrigger;

    // Start is called before the first frame update
    void Start()
    {
        //agentAttackTrigger = new AgentAttackTrigger();
        Transform parentTransform = transform.parent;//获取父物体
        AgentObj = parentTransform.gameObject;

        agent = AgentObj.GetComponent<Agent>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="Enemy"&&agent.AgentInfo.AgentRemainResistNumber>0)//尚可阻挡
        {
            enemy=other.gameObject.GetComponent<Enemy>();
            //agent.AgentLogic.ResistedQueue.Enqueue(enemy);

            //agent.AgentLogic.EnemyObj= other.gameObject;

            //if(agent.AgentLogic.ResistedQueue.Count!=0)
            //    agent.AgentLogic.enemy=agent.AgentLogic.ResistedQueue.Peek();
            //else
            //    agent.AgentLogic.enemy=other.gameObject.GetComponent<Enemy>();

            if(agent.AgentLogic.ResistedQueue.Count==0)
               agent.AgentLogic.enemy=other.gameObject.GetComponent<Enemy>();


                agent.AgentLogic.agentState = AgentState.Attack;
            EnemyObj=other.gameObject;
            Debug.Log("剩余阻挡中敌人数量：" + agent.AgentLogic.ResistedQueue.Count);
          //  enemy = EnemyObj.GetComponent<Enemy>();
            //agent.AgentLogic.EnemyObj = EnemyObj;
            //agent.AgentLogic.enemy = EnemyObj.GetComponent<Enemy>();

        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && agent.AgentLogic.EnemyObj == null)
        {
            agent.AgentLogic.EnemyObj = other.gameObject;
            agent.AgentLogic.enemy = agent.AgentLogic.EnemyObj.GetComponent<Enemy>();
            agent.AgentLogic.agentState = AgentState.Attack;
            EnemyObj = other.gameObject;
            //  enemy = EnemyObj.GetComponent<Enemy>();
            //agent.AgentLogic.EnemyObj = EnemyObj;
            //agent.AgentLogic.enemy = EnemyObj.GetComponent<Enemy>();

        }
    }
}
