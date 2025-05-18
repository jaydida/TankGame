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
            //ȡ����Ϸ��ͣ
            Time.timeScale = 1;
            //�����ݼ�¼�����а���  
            GameDataMgr.Instance.AddRankInfo(inputInfo.content.text, GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);
            //�ص���������
            SceneManager.LoadScene("BeginScene");
        };

        HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
