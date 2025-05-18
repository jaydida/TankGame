using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;
    public CustomGUIButton btnClose;

    // Start is called before the first frame update
    void Start()
    {
        sliderMusic.changeValue += (value) =>
        {
            //处理音乐的变化
            GameDataMgr.Instance.ChangeBKValue(value);
        };

        sliderSound.changeValue += (value) =>
        {
            //处理音效的变化
            GameDataMgr.Instance.ChangeSoundValue(value);
        };

        togMusic.changeValue += (value) =>
        {
            //处理音乐的开关
            GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        };

        togSound.changeValue += (value) =>
        {
            //处理音效的开关
            GameDataMgr.Instance.OpenOrCloseSound(value);
        };

        btnClose.clickEvent += () =>
        {
            //关闭设置面板
            HidePanel();

            //该脚本在多个场景中都需要使用
            //避免出现问题，所以需要判断当前激活的场景
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowPanel();
            }
        };
        //不能直接隐藏，这样的话会导致面板的Awake方法不会被调用，事件监听函数也不会被注册
        //所以我们在显示面板的时候  先注册事件监听函数
        //然后隐藏
        HidePanel();
    }
    /// <summary>
    /// 更新面板显示的信息
    /// </summary>
    public void UpdataPanleInfo()
    {
        //我们面板上的信息都是根据音效数据来 更新的
        //得到音效数据
        MusicData data = GameDataMgr.Instance.musicData;

        //设置面板上的内容
        sliderMusic.nowValue = data.bkValue;
        sliderSound.nowValue = data.soundValue;
        togMusic.isSel = data.isOpenBK;
        togSound.isSel = data.isOpenSound;
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        //更新面板上的信息
        UpdataPanleInfo();
    }

    public override void HidePanel()
    {
        base.HidePanel();
        //恢复时间缩放值
        Time.timeScale = 1;
    }

}
