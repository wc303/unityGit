using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public AgentInfo AgentInfo;
    public AgentLogic AgentLogic;
    
         
    // Start is called before the first frame update
    void Start()
    {
        AgentInfo=new AgentInfo();
        AgentLogic=new AgentLogic();

        //干员初始面板属性
        AgentInfo.AgentPrimaryMaxHP=1000;//干员最大血量
        AgentInfo.AgentPrimaryATK =50;//干员初始攻击
        AgentInfo.AgentPrimaryATKSpeed=100;//初始攻击速度
        AgentInfo.AgentPrimaryATKInterval = 2;//初始攻击间隔
        AgentInfo.AgentPrimaryDFE=5;//干员初始物理防御
        AgentInfo.AgentPrimarySpellDFE=0;//干员初始法抗
        AgentInfo.AgentPrimaryMaxResistNumber=3;//最大阻挡数
        AgentInfo.AgentPrimaryCost=10;//所需费用
        AgentInfo.AgentPrimaryRedeploymentTime=70f;//再部署时间
        AgentInfo.AgentPrimaryTauntPoint = 1;//嘲讽值


        //战斗过程中可改变面板属性
        AgentInfo.AgentMaxHP = 1000;//当前最大血量
        AgentInfo.AgentHP=1000;//干员当前血量
        AgentInfo.AgentATK=15;//干员当前攻击
        AgentInfo.AgentATKSpeed = 100;//当前攻击速度
        AgentInfo.AgentATKInterval = 2;//当前攻击间隔
        AgentInfo.AgentDFE=5;//当前防御
        AgentInfo.AgentSpellDFE=0;//当前法抗
        AgentInfo.AgentMaxResistNumber= AgentInfo.AgentPrimaryMaxResistNumber;//当前最大阻挡数
        AgentInfo.AgentRemainResistNumber = AgentInfo.AgentPrimaryMaxResistNumber;//当前剩余阻挡数
        AgentInfo.AgentDamageReduction=0;//减伤比例
        AgentInfo.AgentCost=10;//费用
        AgentInfo.AgentRedeploymentTime = 70f;//再部署时间

        //战斗中才会存在的属性
        AgentInfo.AgentTauntPoint = 1;//嘲讽值

        AgentInfo.AgentATKType = AgentATKType.physics;//物伤

        AgentLogic.AgentObj=this.gameObject;
        //AgentLogic.agent=AgentLogic.AgentObj.GetComponent<Agent>();
        AgentLogic.agent = this;
        AgentLogic.agentState=AgentState.Idle;//初始为待机

        AgentLogic.trigger = GetComponentInChildren<AgentAttackTrigger>();
        AgentLogic.ResistedQueue=new Queue<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        AgentLogic.AgentStateControl();
        if (AgentInfo.AgentHP <= 0)
        {
            AgentLogic.agentState = AgentState.Death;
        }
    }
}
