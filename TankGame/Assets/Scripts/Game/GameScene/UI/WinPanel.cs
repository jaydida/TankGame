using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIButton btnSure;
    public CustomGUIInput inputInfo;

    // Start is called before the first frame update
    void Start()
    {
        btnSure.clickEvent += () =>
        {
            //取消游戏暂停
            Time.timeScale = 1;
            //把数据记录到排行榜中  
            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text, GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);
            //回到主场景中
            SceneManager.LoadScene("BeginScene");
        };

        HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
