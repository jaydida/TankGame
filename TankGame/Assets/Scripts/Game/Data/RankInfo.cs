using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���а�������
/// </summary>
public class RankInfo 
{
    public string name;
    public int score;
    public float time;

    //������д�޲ι��죬��Ϊд���вι��죬�����������Զ������޲ι���
    public RankInfo()
    {
        
    }

    public RankInfo(string name, int score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }                                        
}


public class RankList
{
    //���а��б�
    public List<RankInfo> list;
}