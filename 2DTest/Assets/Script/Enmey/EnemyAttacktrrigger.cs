using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public Enemy enemy;
    public Agent agent;

    private void OnTriggerEnter2D(Collider2D other)//±»×èµ²
    {
        if (other.gameObject.tag == "Agent")
        {
            enemy.EnemyLogic.enemyState = EnemyState.Attack;//×èµ²¹¥»÷
            enemy.EnemyLogic.AgentObj = other.gameObject;
        }

    }
    private void OnTriggerExit2D(Collider2D other)//È¡Ïû×èµ²
    {
        if (other.gameObject.tag == "Agent")
        {
            enemy.EnemyLogic.enemyState = EnemyState.Move;//¼ÌÐøÒÆ¶¯
            enemy.EnemyLogic.AgentObj = null;
        }

    }
}
