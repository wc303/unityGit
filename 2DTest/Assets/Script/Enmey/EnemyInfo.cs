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
    public GameObject EnemyObj;//��������

    public int EnemyHP;//��ǰѪ��
    public int EnemyMaxHP;//���Ѫ��
    public float EnemyMoveSpeed;//�ƶ��ٶ�
    public int EnemyATK;//������
    public float EnemyATKSpeed;//�����ٶ�
    public int EnemyDFE;//�������
    public float EnemySpellDFE;//��������
    public int EnemyResistNumber;//���������赲��
    public int EnemyWeight;//��������
    public float EnemyDamageReduction;//���˼��˱���
    public int EnemyTauntPoint;//���˳���ֵ
    public EnemyATKType EnemyATKType;
}