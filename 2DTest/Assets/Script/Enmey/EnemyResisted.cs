using UnityEngine;

public class EnemyResisted : MonoBehaviour
{
    private Enemy enemy;
    private EnemyLogic enemyLogic;
    private Agent agent;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        if (enemy == null)
        {
            Debug.LogError("未找到 Enemy 组件！");
            return;
        }

        enemyLogic = enemy.EnemyLogic;
        if (enemyLogic == null)
        {
            Debug.LogError("未找到 EnemyLogic 组件！");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Agent"))
        {
            enemyLogic.agent =agent = other.GetComponent<Agent>();
            if (enemyLogic != null&&agent!=null)
            {
                Debug.Log("触发 Agent，当前状态：" + enemyLogic.enemyState);
                if (agent.AgentInfo.AgentRemainResistNumber > 0)
                {
                    agent.AgentLogic.ResistedQueue.Enqueue(enemy);//加入阻挡队列

                    agent.AgentInfo.AgentRemainResistNumber--;
                    enemyLogic.enemyState = EnemyState.Resisted;
                    Debug.Log("修改后状态：" + enemyLogic.enemyState);
                }
                else{ Debug.Log("阻挡数不足");}
            }
            else{Debug.LogError("enemyLogic 为空！");}
        }
    }
}
