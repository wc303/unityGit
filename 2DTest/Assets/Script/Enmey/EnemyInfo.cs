using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyATKType
    {
        physics,
        spell
    }

[System.Serializable]
public class EnemyInfo
{
    public GameObject EnemyObj;//敌人物体

    public int EnemyHP;//当前血量
    public int EnemyMaxHP;//最大血量
    public float EnemyMoveSpeed;//移动速度
    public int EnemyATK;//攻击力
    public float EnemyATKSpeed;//攻击速度
    public int EnemyDFE;//物理防御
    public float EnemySpellDFE;//法术防御
    public int EnemyResistNumber;//敌人所需阻挡数
    public int EnemyWeight;//敌人重量
    public float EnemyDamageReduction;//敌人减伤比例
    public int EnemyTauntPoint;//敌人嘲讽值
    public EnemyATKType EnemyATKType;
}