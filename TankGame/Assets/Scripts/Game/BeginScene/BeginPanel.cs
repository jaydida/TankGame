using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    //�������������ĳ�Ա����  �����������ؼ�
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    // Start is called before the first frame update
    void Start()
    {
        //Ŀ������Ϊ�������̹�˵�ͷ��ת��  ������������ڴ�����  ��������ȥ���ÿ���
        Cursor.lockState = CursorLockMode.Confined;

        //����һ�ΰ�ť�������Ҫ��ʲô
        //�������ť��ʱ��  ���ø��¼�
        btnBegin.clickEvent += () => 
        { 
            //�л�����
            SceneManager.LoadScene("GameScene");
        };

        btnSetting.clickEvent += () =>
        {
            //���������
            SettingPanel.Instance.ShowPanel();
            //���ص�ǰ���  ���⴩͸
            HidePanel();
        };

        btnQuit.clickEvent += () =>
        {
            //�˳���Ϸ
            Application.Quit();
        };

        btnRank.clickEvent += () =>
        {
            RankPanel.Instance.ShowPanel();
            //���ص�ǰ���  ���⴩͸
            HidePanel();
        };
    }

   
}
