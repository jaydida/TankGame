using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //��ȡ�ؼ�  ���������ϵĿؼ�����  ֮��ſ���
    public CustomGuILabel scoreLabel;
    public CustomGuILabel timeLabel;
    public CustomGUITexture HPTexture;
    public CustomGUITexture mpTexture;
    public CustomGUIButton QuitButton;
    public CustomGUIButton setButton;

    [HideInInspector]//������ʾ��Inspector�����
    public int nowScore = 0;//��������¼����

    public float hpWidth = 350;//Ѫ���Ŀ��

    [HideInInspector]
    public float nowTime = 0;//��ǰʱ��
    private int time = 0;//�������ʱ�任��

    // Start is called before the first frame update
    void Start()
    {
        //���������ϵ�һЩ�����¼�
        setButton.clickEvent += () =>
        {
            //������ð�ť
            //�������ý���
            //SetPanel.Instance.ShowPanel();
            SettingPanel.Instance.ShowPanel();
            //�ı�ʱ������ֵΪ0 ����ʱ����ͣ
            Time.timeScale = 0;
        };

        QuitButton.clickEvent += () =>
        {
            //����˳���ť
            //�������ؽ��棬��ֹ�����
            QuitPanel.Instance.ShowPanel();

            //�ı�ʱ������ֵΪ0 ����ʱ����ͣ
            Time.timeScale = 0;
        };
        //UpdateScore(20);//��������
        //UpdateHp(100, 30);//��������
    }

    // Update is called once per frame
    void Update()
    {
        //ͨ��֡���ʱ���������ۼӣ�  �Ƚ�׼ȷ
        nowTime += Time.deltaTime;

        //����ת���� ʱ �� ��
        time = (int)nowTime;
        timeLabel.content.text = "";//�����ܼ��ٱ�����ʹ��
        //ʱ
        if (time / 3600 > 0)
        {
            timeLabel.content.text += (time / 3600) + "ʱ";
        }
        //��
        if ((time % 3600) / 60 > 0)
        {
            timeLabel.content.text += ((time % 3600) / 60) + "��";
        }
        //��
        if (time % 60 > 0)
        {
            timeLabel.content.text += (time % 60) + "��";
        }
    }
    /// <summary>
    /// �ṩ���ⲿ�ļӷַ���
    /// </summary>
    public void UpdateScore(int score )
    {
        nowScore += score;
        //���·���
        scoreLabel.content.text = nowScore.ToString();
    }
    /// <summary>
    /// ����Ѫ��
    /// </summary>
    public void UpdateHp(int maxHP, int currentHP)
    {
        HPTexture.guiPos.width = (float)currentHP / maxHP * hpWidth;
    }

    
}
