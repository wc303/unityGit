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
            Debug.LogError("δ�ҵ� Enemy �����");
            return;
        }

        enemyLogic = enemy.EnemyLogic;
        if (enemyLogic == null)
        {
            Debug.LogError("δ�ҵ� EnemyLogic �����");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Agent"))
        {
            enemyLogic.agent =agent = other.GetComponent<Agent>();
            if (enemyLogic != null&&agent!=null)
            {
                Debug.Log("���� Agent����ǰ״̬��" + enemyLogic.enemyState);
                if (agent.AgentInfo.AgentRemainResistNumber > 0)
                {
                    agent.AgentLogic.ResistedQueue.Enqueue(enemy);//�����赲����

                    agent.AgentInfo.AgentRemainResistNumber--;
                    enemyLogic.enemyState = EnemyState.Resisted;
                    Debug.Log("�޸ĺ�״̬��" + enemyLogic.enemyState);
                }
                else{ Debug.Log("�赲������");}
            }
            else{Debug.LogError("enemyLogic Ϊ�գ�");}
        }
    }
}
