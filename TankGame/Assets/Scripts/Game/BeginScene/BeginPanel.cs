using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    //首先声明公共的成员变量  来关联各个控件
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    // Start is called before the first frame update
    void Start()
    {
        //目的是因为方便控制坦克的头部转向  所以锁定鼠标在窗口内  避免鼠标出去不好控制
        Cursor.lockState = CursorLockMode.Confined;

        //监听一次按钮点击过后要做什么
        //当点击按钮的时候  调用该事件
        btnBegin.clickEvent += () => 
        { 
            //切换场景
            SceneManager.LoadScene("GameScene");
        };

        btnSetting.clickEvent += () =>
        {
            //打开设置面板
            SettingPanel.Instance.ShowPanel();
            //隐藏当前面板  避免穿透
            HidePanel();
        };

        btnQuit.clickEvent += () =>
        {
            //退出游戏
            Application.Quit();
        };

        btnRank.clickEvent += () =>
        {
            RankPanel.Instance.ShowPanel();
            //隐藏当前面板  避免穿透
            HidePanel();
        };
    }

   
}
