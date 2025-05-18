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
            //�˳���Ϸ  �ص�������
            SceneManager.LoadScene("BeginScene");

        };

        btnCancel.clickEvent += () =>
        {
            //ȡ���˳� �ر����
            HidePanel();
        };

        btnClose.clickEvent += () => 
        {
            //�ر����
            HidePanel();
        };
        //��ʼʱ�����Լ�
        HidePanel();
    }

    public override void HidePanel()
    {
        base.HidePanel();
        //�ָ�ʱ������ֵ
        Time.timeScale = 1;
    }

}
