using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    //����public��  �ؼ�����

    //��Ϊ�ؼ�̫�࣬�ϵû�������̫����  ����ͨ���������
    public CustomGUIButton btnClose;
    //private List<CustomGuILabel> labRank = new List<CustomGuILabel>();
    private List<CustomGuILabel> labName = new List<CustomGuILabel>();
    private List<CustomGuILabel> labScore = new List<CustomGuILabel>();
    private List<CustomGuILabel> labTime = new List<CustomGuILabel>();

    //ʱ�任��
    int hour = 0;
    int minute = 0;
    int second = 0;


    // Start is called before the first frame update
    void Start()
    {
        //�����¼������߼�
        for (int i = 1; i < 11; i++)
        {
            //ͨ�����ֲ��ҿؼ�his.transform.Find��ֻ�����Ӷ��󣬶��Ӷ�����Ӷ�������
            //���Կ����� �Ӷ�����/��Ҫ���ҵĶ�����  ��ʵ�ֲ����Ӷ�����Ӷ���
            //labRank.Add( this.transform.Find("Rank/labRank" + i).GetComponent<CustomGuILabel>());
            labName.Add( this.transform.Find("Name/labName" + i).GetComponent<CustomGuILabel>());
            labScore.Add( this.transform.Find("Score/labScore" + i).GetComponent<CustomGuILabel>());
            labTime.Add( this.transform.Find("Time/labTime" + i).GetComponent<CustomGuILabel>());
        }

        btnClose.clickEvent += () =>
        {
            HidePanel();
            BeginPanel.Instance.ShowPanel();
        };
        //TODO
        //����������� Ӧ�ÿ��ǵ�����һ��ʱ  ��ʾ����ͬһ���˶������µ����
        //�����������
        //GameDataMgr.Instance.AddRankInfo("С��", 100, 1000);

        //���а�����ʱ ���ڹر�����״̬
        HidePanel();
    }
    public override void ShowPanel()
    {
        base.ShowPanel();
        UpdatePanelInfo();
    }

    //����������а�����  �������
    public void UpdatePanelInfo()
    {
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;

        if (list == null)
        {
            return;
        }
        else
        {
            for (int i = 0; i < list.Count; i++)
            {
                //labRank[i].content.text = ("��" + i + 1 + "��").ToString();
                labName[i].content.text = list[i].name;
                labScore[i].content.text = list[i].score.ToString();
                //ʱ��  �洢��ʱ�䵥λ����
                //������  ת����  ʱ  �� ��
                hour = (int) list[i].time / 3600;
                minute = ((int) list[i].time % 3600) / 60;
                second = (int) list[i].time % 60;
                labTime[i].content.text = (hour + "ʱ" + minute + "��" + second + "��").ToString();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
