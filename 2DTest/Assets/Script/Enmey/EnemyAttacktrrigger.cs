using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public Enemy enemy;
    public Agent agent;

    private void OnTriggerEnter2D(Collider2D other)//���赲
    {
        if (other.gameObject.tag == "Agent")
        {
            enemy.EnemyLogic.enemyState = EnemyState.Attack;//�赲����
            enemy.EnemyLogic.AgentObj = other.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D other)//ȡ���赲
    {
        if (other.gameObject.tag == "Agent")
        {
            enemy.EnemyLogic.enemyState = EnemyState.Move;//�����ƶ�
            enemy.EnemyLogic.AgentObj = null;
        }

    }
}
