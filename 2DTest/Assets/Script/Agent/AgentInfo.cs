using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AgentInfo
{
    //干员初始属性
    public int AgentPrimaryMaxHP;//干员初始最大血量
    public float AgentPrimaryATK;//干员初始攻击
    public int AgentPrimaryATKSpeed;//初始攻击速度
    public int AgentPrimaryATKInterval;//初始攻击间隔
    public int AgentPrimaryDFE;//干员初始物理防御
    public int AgentPrimarySpellDFE;//干员初始法抗
    public int AgentPrimaryMaxResistNumber;//初始最大阻挡数
    public int AgentPrimaryCost;//初始所需费用
    public float AgentPrimaryRedeploymentTime;//初始再部署时间
    public int AgentPrimaryTauntPoint;//初始嘲讽值



    //战斗过程中可改变的值
    public int AgentMaxHP;//战斗中的最大血量
    public int AgentHP;//干员当前血量
    public int AgentATK;//干员当前攻击
    public int AgentATKSpeed;//当前攻击速度
    public float AgentATKInterval;//当前攻击间隔
    public int AgentDFE;//当前防御
    public float AgentSpellDFE;//当前法抗
    public int AgentMaxResistNumber;//当前最大阻挡数
    public int AgentRemainResistNumber;//当前剩余阻挡数
    public float AgentDamageReduction;//减伤比例
    public int AgentCost;//当前部署费用
    public float AgentRedeploymentTime;//再部署时间

    //战斗中会出现的值
    public int AgentTauntPoint;//当前嘲讽值

    public AgentATKType AgentATKType;



    
}  
public enum AgentATKType//攻击类型
    {
        physics,
        spell
    }
public enum OperatorType { Melee, Ranged }