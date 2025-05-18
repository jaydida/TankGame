using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    //�̳�monobehaviour ����ֱ��newһ���������
    private static BKMusic instance;
    public static BKMusic Instance => instance;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        //��ȡ����
        //�������߹رձ�������
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBK);

    }
    /// <summary>
    /// �ı䱳�����ִ�С
    /// </summary>
    /// <param name="value"></param>
    public void ChangeValue(float value)
    {
        audioSource.volume = value;
    }
    /// <summary>
    /// ���ر�������
    /// </summary>
    /// <param name="isOpen"></param>
    public void ChangeOpen(bool isOpen)
    {
        //�������ǲ�����
        //û�п������ǽ���
        audioSource.mute = !isOpen;
    }
}
