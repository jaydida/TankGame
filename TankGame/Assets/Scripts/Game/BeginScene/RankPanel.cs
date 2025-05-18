using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    //关联public的  控件对象

    //因为控件太多，拖得话工作量太大了  这里通过代码查找
    public CustomGUIButton btnClose;
    //private List<CustomGuILabel> labRank = new List<CustomGuILabel>();
    private List<CustomGuILabel> labName = new List<CustomGuILabel>();
    private List<CustomGuILabel> labScore = new List<CustomGuILabel>();
    private List<CustomGuILabel> labTime = new List<CustomGuILabel>();

    //时间换算
    int hour = 0;
    int minute = 0;
    int second = 0;


    // Start is called before the first frame update
    void Start()
    {
        //处理事件监听逻辑
        for (int i = 1; i < 11; i++)
        {
            //通过名字查找控件his.transform.Find，只能找子对象，而子对象的子对象不能找
            //所以可以用 子对象名/需要查找的对象名  来实现查找子对象的子对象
            //labRank.Add( this.transform.Find("Rank/labRank" + i).GetComponent<CustomGuILabel>());
            labName.Add( this.transform.Find("Name/labName" + i).GetComponent<CustomGuILabel>());
            labScore.Add( this.transform.Find("Score/labScore" + i).GetComponent<CustomGuILabel>());
            labTime.Add( this.transform.Find("Time/labTime" + i).GetComponent<CustomGuILabel>());
        }

        btnClose.clickEvent += () =>
        {
            HidePanel();
            BeginPanel.Instance.ShowPanel();
        };
        //TODO
        //这里添加数据 应该考虑当名字一样时  表示的是同一个人而不是新的玩家
        //测试添加数据
        //GameDataMgr.Instance.AddRankInfo("小明", 100, 1000);

        //排行榜面板打开时 是在关闭隐藏状态
        HidePanel();
    }
    public override void ShowPanel()
    {
        base.ShowPanel();
        UpdatePanelInfo();
    }

    //处理根据排行榜数据  更新面板
    public void UpdatePanelInfo()
    {
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;

        if (list == null)
        {
            return;
        }
        else
        {
            for (int i = 0; i < list.Count; i++)
            {
                //labRank[i].content.text = ("第" + i + 1 + "名").ToString();
                labName[i].content.text = list[i].name;
                labScore[i].content.text = list[i].score.ToString();
                //时间  存储的时间单位是秒
                //把秒数  转换成  时  分 秒
                hour = (int) list[i].time / 3600;
                minute = ((int) list[i].time % 3600) / 60;
                second = (int) list[i].time % 60;
                labTime[i].content.text = (hour + "时" + minute + "分" + second + "秒").ToString();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
