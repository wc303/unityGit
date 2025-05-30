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

        //��Ա��ʼ�������
        AgentInfo.AgentPrimaryMaxHP=1000;//��Ա���Ѫ��
        AgentInfo.AgentPrimaryATK =50;//��Ա��ʼ����
        AgentInfo.AgentPrimaryATKSpeed=100;//��ʼ�����ٶ�
        AgentInfo.AgentPrimaryATKInterval = 2;//��ʼ�������
        AgentInfo.AgentPrimaryDFE=5;//��Ա��ʼ�������
        AgentInfo.AgentPrimarySpellDFE=0;//��Ա��ʼ����
        AgentInfo.AgentPrimaryMaxResistNumber=3;//����赲��
        AgentInfo.AgentPrimaryCost=10;//�������
        AgentInfo.AgentPrimaryRedeploymentTime=70f;//�ٲ���ʱ��
        AgentInfo.AgentPrimaryTauntPoint = 1;//����ֵ


        //ս�������пɸı��������
        AgentInfo.AgentMaxHP = 1000;//��ǰ���Ѫ��
        AgentInfo.AgentHP=1000;//��Ա��ǰѪ��
        AgentInfo.AgentATK=15;//��Ա��ǰ����
        AgentInfo.AgentATKSpeed = 100;//��ǰ�����ٶ�
        AgentInfo.AgentATKInterval = 2;//��ǰ�������
        AgentInfo.AgentDFE=5;//��ǰ����
        AgentInfo.AgentSpellDFE=0;//��ǰ����
        AgentInfo.AgentMaxResistNumber= AgentInfo.AgentPrimaryMaxResistNumber;//��ǰ����赲��
        AgentInfo.AgentRemainResistNumber = AgentInfo.AgentPrimaryMaxResistNumber;//��ǰʣ���赲��
        AgentInfo.AgentDamageReduction=0;//���˱���
        AgentInfo.AgentCost=10;//����
        AgentInfo.AgentRedeploymentTime = 70f;//�ٲ���ʱ��

        //ս���вŻ���ڵ�����
        AgentInfo.AgentTauntPoint = 1;//����ֵ

        AgentInfo.AgentATKType = AgentATKType.physics;//����

        AgentLogic.AgentObj=this.gameObject;
        //AgentLogic.agent=AgentLogic.AgentObj.GetComponent<Agent>();
        AgentLogic.agent = this;
        AgentLogic.agentState=AgentState.Idle;//��ʼΪ����

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
