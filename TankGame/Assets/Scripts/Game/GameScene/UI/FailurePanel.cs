using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailurePanel : BasePanel<FailurePanel>
{
    public CustomGUIButton btnBack;
    public CustomGUIButton btnGoOn;
    // Start is called before the first frame update
    void Start()
    {
        btnBack.clickEvent += () =>
        {
            //ȡ����ͣ
            Time.timeScale = 1.0f;
            //�л�����
            SceneManager.LoadScene("BeginScene");
        };

        btnGoOn.clickEvent += () =>
        {
            //ȡ����ͣ
            Time.timeScale = 1.0f;
            //�ٴ��л���  ��Ϸ����  �Ϳ���  �ﵽ�����������¼���  ��ͷ��ʼ��  Ŀ��
            SceneManager.LoadScene("GameScene");
        };
        HidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
