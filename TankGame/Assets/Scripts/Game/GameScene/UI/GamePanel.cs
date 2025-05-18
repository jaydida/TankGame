using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //获取控件  关联场景上的控件对象  之后号控制
    public CustomGuILabel scoreLabel;
    public CustomGuILabel timeLabel;
    public CustomGUITexture HPTexture;
    public CustomGUITexture mpTexture;
    public CustomGUIButton QuitButton;
    public CustomGUIButton setButton;

    [HideInInspector]//不用显示在Inspector面板上
    public int nowScore = 0;//将分数记录下来

    public float hpWidth = 350;//血条的宽度

    [HideInInspector]
    public float nowTime = 0;//当前时间
    private int time = 0;//方便进行时间换算

    // Start is called before the first frame update
    void Start()
    {
        //监听界面上的一些操作事件
        setButton.clickEvent += () =>
        {
            //点击设置按钮
            //弹出设置界面
            //SetPanel.Instance.ShowPanel();
            SettingPanel.Instance.ShowPanel();
            //改变时间缩放值为0 就是时间暂停
            Time.timeScale = 0;
        };

        QuitButton.clickEvent += () =>
        {
            //点击退出按钮
            //弹出返回界面，防止误操作
            QuitPanel.Instance.ShowPanel();

            //改变时间缩放值为0 就是时间暂停
            Time.timeScale = 0;
        };
        //UpdateScore(20);//测试数据
        //UpdateHp(100, 30);//测试数据
    }

    // Update is called once per frame
    void Update()
    {
        //通过帧间隔时间来进行累加，  比较准确
        nowTime += Time.deltaTime;

        //把秒转换成 时 分 秒
        time = (int)nowTime;
        timeLabel.content.text = "";//这样能减少变量的使用
        //时
        if (time / 3600 > 0)
        {
            timeLabel.content.text += (time / 3600) + "时";
        }
        //分
        if ((time % 3600) / 60 > 0)
        {
            timeLabel.content.text += ((time % 3600) / 60) + "分";
        }
        //秒
        if (time % 60 > 0)
        {
            timeLabel.content.text += (time % 60) + "秒";
        }
    }
    /// <summary>
    /// 提供给外部的加分方法
    /// </summary>
    public void UpdateScore(int score )
    {
        nowScore += score;
        //更新分数
        scoreLabel.content.text = nowScore.ToString();
    }
    /// <summary>
    /// 更新血条
    /// </summary>
    public void UpdateHp(int maxHP, int currentHP)
    {
        HPTexture.guiPos.width = (float)currentHP / maxHP * hpWidth;
    }

    
}
