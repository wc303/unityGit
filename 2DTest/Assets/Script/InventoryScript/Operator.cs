//using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Operator", menuName = "Inventory/New Operator")]
public class Operater : ScriptableObject
{
    public string operatorName;//����
    public Sprite operatorLevel;//�ȼ�
    public Sprite operatorImage;//����
    public int operatorStarLevel;//�Ǽ�
    public OperatorValueInfo operatorValueInfo;//��ֵ
    public int ConfidenceValue;//����ֵ
    public OperatorCareer operatorCareer;//ְҵ
    [TextArea]
    public string branchesSpec;//ְҵģ������

}
public enum OperatorCareer
{
    
    XianFeng,
    JinWei,
    ZhongZhuang,
    JuJi,
    ShuShi,
    FuZhu,
    TeZhong
}
public enum XianFengBranches
{

}
public enum JinWeiBranches
{

}
public enum ZhongZhuangBranches
{

}
public enum JuJiBranches
{

}
public enum ShuShiBranches
{

}
public enum FuZhuBranches
{

}
public enum TeZhongBranches
{

}

public class OperatorValueInfo
{
    public int opratorHP;//Ѫ��
    public int operaterATK;//����������
    public int operatorDFE;//�����￹
    public int operatorSpellDFE;//����
    public int operatorCost;//����
    public int operatorRePlaceTime;//�ٲ���ʱ��
    public int operatorResistNumber;//�赲��
    public int operatorATKSpeed;//����
}
