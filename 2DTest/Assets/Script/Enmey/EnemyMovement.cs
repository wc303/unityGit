using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour
{
    public Enemy enemy;
    private EnemyInfo enemyInfo;
    private EnemyLogic enemyLogic;
    public Transform[] waypoints; // ����·����
    private int currentWaypoint = 0;
    public GameObject finalPos; // ����·����
    public float movespeed ;

    private void Start()
    {
        enemy=GetComponent<Enemy>();
        enemyInfo=enemy.EnemyInfo;
        enemyLogic=enemy.EnemyLogic;
    }
    void Update()
    {

        if (enemyLogic.enemyState == EnemyState.Move)
        {
            movespeed = enemyInfo.EnemyMoveSpeed;

            if (currentWaypoint >= waypoints.Length) return;

            // ��ǰ·�����ƶ�
            transform.position = Vector3.MoveTowards(
                transform.position,
                waypoints[currentWaypoint].position,
                movespeed * Time.deltaTime
            );

            // ����·������л���һ��
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
            {
                currentWaypoint++;
            }
            if (Vector2.Distance(transform.position, finalPos.transform.position) <= 0.1f)
            {
                EnemyDead();
            }
        }
    }
    void EnemyDead()
    {
        GameObject.Destroy(this.gameObject); 

    }
}