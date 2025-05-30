//using Palmmedia.ReportGenerator.Core.Reporting.Builders.Rendering;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Operator", menuName = "Inventory/New Operator")]
public class Operater : ScriptableObject
{
    public string operatorName;//名字
    public Sprite operatorLevel;//等级
    public Sprite operatorImage;//立绘
    public int operatorStarLevel;//星级
    public OperatorValueInfo operatorValueInfo;//数值
    public int ConfidenceValue;//信赖值
    public OperatorCareer operatorCareer;//职业
    [TextArea]
    public string branchesSpec;//职业模板特性

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
    public int opratorHP;//血量
    public int operaterATK;//基础攻击力
    public int operatorDFE;//基础物抗
    public int operatorSpellDFE;//法抗
    public int operatorCost;//费用
    public int operatorRePlaceTime;//再部署时间
    public int operatorResistNumber;//阻挡数
    public int operatorATKSpeed;//攻速
}
