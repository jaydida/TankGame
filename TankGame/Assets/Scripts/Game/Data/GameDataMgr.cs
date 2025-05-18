using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��Ϸ���ݹ����� ��һ������ģʽ����
/// </summary>
public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();//ʹ��new  ���ǵ��ù��캯��
    public static GameDataMgr Instance
    {
        get
        {
            return instance;
        }
    }

    //��Ч���ݶ���
    public MusicData musicData;
    //���а����ݶ���
    public RankList rankData;
    private GameDataMgr()
    {
        //���Գ�ʼ�� ��Ϸ����
        musicData = PlayerPrefsDataMgr.Instance.LoadDate(typeof (MusicData), "Music") as MusicData;
        //�����һ�ν�����Ϸ  û����Ч����  ��ô���Ե�����Ҫ����false Ҫ����0
        if (!musicData.notFirst)
        {
            musicData.isOpenBK = true;
            musicData.isOpenSound = true;
            musicData.bkValue = 1;
            musicData.soundValue = 1;
            musicData.notFirst = true;
            PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
        }

        //��ʼ�����а�����
        rankData = PlayerPrefsDataMgr.Instance.LoadDate(typeof(RankList), "Rank") as RankList;
    }

    //�ṩAPI���ⲿ  �������ݵĸı�洢

    //�������߹رձ�������
    public void OpenOrCloseBKMusic(bool isOpen)
    {
        musicData.isOpenBK = isOpen;
        //�������߹رձ�������
        BKMusic.Instance.ChangeOpen(isOpen);
        //ÿ�θı�����  ��Ҫ�洢һ�Σ���֤����ÿһ�ζ����ϴδ����Ϣ
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }

    //�������߹ر���Ч
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isOpenSound = isOpen;
        //ÿ�θı�����  ��Ҫ�洢һ�Σ���֤����ÿһ�ζ����ϴδ����Ϣ
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }

    //���ñ������ִ�С
    public void ChangeBKValue(float value)
    {
        musicData.bkValue = value;
        //�ı䱳�����ִ�С
        BKMusic.Instance.ChangeValue(value);
        //ÿ�θı�����  ��Ҫ�洢һ�Σ���֤����ÿһ�ζ����ϴδ����Ϣ
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }

    //������Ч��С
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        //ÿ�θı�����  ��Ҫ�洢һ�Σ���֤����ÿһ�ζ����ϴδ����Ϣ
        PlayerPrefsDataMgr.Instance.SaveDate(musicData, "Music");
    }


    //�ṩһ��  �����а���������ݵķ���
    public void AddRankInfo(string name, int score, float time)
    {
        rankData.list.Add(new RankInfo(name, score, time));
        //����
        rankData.list.Sort((x, y) => x.score > y.score ? -1 : 1);
        //{
        //    //if (x.time > y.time)
        //    //{
        //    //    return -1;
        //    //}
        //    //else if (x.time < y.time)
        //    //{
        //    //    return 1;
        //    //}
        //    //else 
        //    //{
        //    //    return 0;
        //    //}

        //});
        //�������  �Ƴ�10�����������
        //��β����ǰ���� �Ƴ�ÿһ��
        for (int i = rankData.list.Count -1 ; i >= 10 ; i--)
        {
            rankData.list.RemoveAt(i);
        }

        //�洢����
        PlayerPrefsDataMgr.Instance.SaveDate(rankData, "Rank");
    }
}
