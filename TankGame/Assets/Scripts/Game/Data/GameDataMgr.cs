using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏数据管理类 是一个单例模式对象
/// </summary>
public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();//使用new  就是调用构造函数
    public static GameDataMgr Instance
    {
        get
        {
            return instance;
        }
    }

    //音效数据对象
    public MusicData musicData;
    //排行榜数据对象
    public RankList rankData;
    private GameDataMgr()
    {
        //可以初始化 游戏数据
        musicData = PlayerPrefsDataMgr.Instance.LoadDate(typeof (MusicData), "Music") as MusicData;
        //如果第一次进入游戏  没有音效数据  那么所以得数据要不是false 要不是0
        if (!musicData.notFirst)
        {
            musicData.isOpenBK = true;
            musicData.isOpenSound = true;
            musicData.bkValue = 1;
            musicData.soundValue = 1;
            musicData.notFirst = true;
            PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
        }

        //初始化排行榜数据
        rankData = PlayerPrefsDataMgr.Instance.LoadDate(typeof(RankList), "Rank") as RankList;
    }

    //提供API给外部  方便数据的改变存储

    //开启或者关闭背景音乐
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenBK = isOpen;
        //开启或者关闭背景音乐
        BKMusic.Instance.ChangeOpen(isOpen);
        //每次改变数据  都要存储一次，保证数据每一次都是上次存的信息
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }

    //开启或者关闭音效
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        //每次改变数据  都要存储一次，保证数据每一次都是上次存的信息
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }

    //设置背景音乐大小
    public void ChangeBKValue(float value)
    {
        musicData.bkValue = value;
        //改变背景音乐大小
        BKMusic.Instance.ChangeValue(value);
        //每次改变数据  都要存储一次，保证数据每一次都是上次存的信息
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }

    //设置音效大小
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        //每次改变数据  都要存储一次，保证数据每一次都是上次存的信息
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }


    //提供一个  在排行榜中添加数据的方法
    public void AddRankInfo(string name, int score, float time)
    {
        rankData.list.Add(new RankInfo(name, score, time));
        //排序
        rankData.list.Sort((x, y) => x.score > y.score ? -1 : 1);
        //{
        //    //if (x.time > y.time)
        //    //{
        //    //    return -1;
        //    //}
        //    //else if (x.time < y.time)
        //    //{
        //    //    return 1;
        //    //}
        //    //else 
        //    //{
        //    //    return 0;
        //    //}

        //});
        //排序过后  移除10条以外的数据
        //从尾部往前遍历 移除每一条
        for (int i = rankData.list.Count -1 ; i >= 10 ; i--)
        {
            rankData.list.RemoveAt(i);
        }

        //存储数据
        PlayerPrefsDataMgr.Instance.SaveDate(rankData, "Rank");
    }
}
