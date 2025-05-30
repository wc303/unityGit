using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AgentInfo
{
    //��Ա��ʼ����
    public int AgentPrimaryMaxHP;//��Ա��ʼ���Ѫ��
    public float AgentPrimaryATK;//��Ա��ʼ����
    public int AgentPrimaryATKSpeed;//��ʼ�����ٶ�
    public int AgentPrimaryATKInterval;//��ʼ�������
    public int AgentPrimaryDFE;//��Ա��ʼ�������
    public int AgentPrimarySpellDFE;//��Ա��ʼ����
    public int AgentPrimaryMaxResistNumber;//��ʼ����赲��
    public int AgentPrimaryCost;//��ʼ�������
    public float AgentPrimaryRedeploymentTime;//��ʼ�ٲ���ʱ��
    public int AgentPrimaryTauntPoint;//��ʼ����ֵ



    //ս�������пɸı��ֵ
    public int AgentMaxHP;//ս���е����Ѫ��
    public int AgentHP;//��Ա��ǰѪ��
    public int AgentATK;//��Ա��ǰ����
    public int AgentATKSpeed;//��ǰ�����ٶ�
    public float AgentATKInterval;//��ǰ�������
    public int AgentDFE;//��ǰ����
    public float AgentSpellDFE;//��ǰ����
    public int AgentMaxResistNumber;//��ǰ����赲��
    public int AgentRemainResistNumber;//��ǰʣ���赲��
    public float AgentDamageReduction;//���˱���
    public int AgentCost;//��ǰ�������
    public float AgentRedeploymentTime;//�ٲ���ʱ��

    //ս���л���ֵ�ֵ
    public int AgentTauntPoint;//��ǰ����ֵ

    public AgentATKType AgentATKType;



    
}  
public enum AgentATKType//��������
    {
        physics,
        spell
    }
public enum OperatorType { Melee, Ranged }