using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 排行榜单条数据
/// </summary>
public class RankInfo 
{
    public string name;
    public int score;
    public float time;

    //这里明写无参构造，因为写了有参构造，编译器不会自动生成无参构造
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
    //排行榜列表
    public List<RankInfo> list;
}