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
            //�������ֵı仯
            GameDataMgr.Instance.ChangeBKValue(value);
        };

        sliderSound.changeValue += (value) =>
        {
            //������Ч�ı仯
            GameDataMgr.Instance.ChangeSoundValue(value);
        };

        togMusic.changeValue += (value) =>
        {
            //�������ֵĿ���
            GameDataMgr.Instance.OpenOrCloseBKMusic(value);
        };

        togSound.changeValue += (value) =>
        {
            //������Ч�Ŀ���
            GameDataMgr.Instance.OpenOrCloseSound(value);
        };

        btnClose.clickEvent += () =>
        {
            //�ر��������
            HidePanel();

            //�ýű��ڶ�������ж���Ҫʹ��
            //����������⣬������Ҫ�жϵ�ǰ����ĳ���
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowPanel();
            }
        };
        //����ֱ�����أ������Ļ��ᵼ������Awake�������ᱻ���ã��¼���������Ҳ���ᱻע��
        //������������ʾ����ʱ��  ��ע���¼���������
        //Ȼ������
        HidePanel();
    }
    /// <summary>
    /// ���������ʾ����Ϣ
    /// </summary>
    public void UpdataPanleInfo()
    {
        //��������ϵ���Ϣ���Ǹ�����Ч������ ���µ�
        //�õ���Ч����
        MusicData data = GameDataMgr.Instance.musicData;

        //��������ϵ�����
        sliderMusic.nowValue = data.bkValue;
        sliderSound.nowValue = data.soundValue;
        togMusic.isSel = data.isOpenBK;
        togSound.isSel = data.isOpenSound;
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        //��������ϵ���Ϣ
        UpdataPanleInfo();
    }

    public override void HidePanel()
    {
        base.HidePanel();
        //�ָ�ʱ������ֵ
        Time.timeScale = 1;
    }

}
