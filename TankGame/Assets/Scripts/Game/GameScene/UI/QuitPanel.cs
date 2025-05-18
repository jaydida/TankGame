using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnCancel;
    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        btnQuit.clickEvent += () =>
        {
            //退出游戏  回到主界面
            SceneManager.LoadScene("BeginScene");

        };

        btnCancel.clickEvent += () =>
        {
            //取消退出 关闭面板
            HidePanel();
        };

        btnClose.clickEvent += () => 
        {
            //关闭面板
            HidePanel();
        };
        //开始时隐藏自己
        HidePanel();
    }

    public override void HidePanel()
    {
        base.HidePanel();
        //恢复时间缩放值
        Time.timeScale = 1;
    }

}
