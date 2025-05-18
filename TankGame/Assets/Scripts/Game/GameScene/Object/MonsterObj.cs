using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObj : TankBaseObj
{
    //1.Ҫ��̹����������֮�������ƶ�
    //��ǰ��Ŀ���
    private Transform targetPos;
    //����õĵ� ����ȥ����
    public Transform[] randomPos;
    //2.̹��Ҫһֱ�����Լ���Ŀ��
    public Transform lookAtTarget;
    //3.��Ŀ�굽��һ����Χ�ڹ���  ���һ��ʱ��  ����һ��Ŀ��
    //�������  ��С���������ʱ  �ͻ���������
    public float fireDis = 5;
    //Ϊ�˱���̫��  ��һ���������ʱ��
    public float fireOffsetTime = 1f;
    private float nowTime;

    //�ӵ�����  BulletObj�����ӵ����� ֻ���ӵ�������ص�һ���Զ���ű�
    public GameObject bullet;
    //�ӵ������
    public Transform[] shootPos;

    //����Ѫ��ͼ  �ⲿ����
    public Texture maxHpBK;
    public Texture hpBK;

    //˽�е�  ��newһ��  ���ǽṹ��Ҫ��Ȼ����
    private Rect maxHpRect ;
    private Rect hpRect;

    //����Ѫ����ʾʱ��
    private float showTime;


    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        #region �����֮�������ƶ��߼�
        //�����Լ���Ŀ���
        this.transform.LookAt(targetPos);
        //��ͣ�����Լ����泯��λ��
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //֪ʶ��  Vector3������һ���õ�������֮�����ķ���
        //�������Сʱ  ��Ϊ������Ŀ�ĵ�  �������һ����
        //�����ƶ���һ��һ����ɢ���ƶ�
        if (Vector3.Distance(transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }
        #endregion

        #region �����Լ���Ŀ��
        if (lookAtTarget != null) 
        {
            tankHead.transform.LookAt(lookAtTarget);
            //���Լ���Ŀ�����ľ���  С�ڵ���  ���õ�  �������ʱ
            if (Vector3.Distance(transform.position, lookAtTarget.position) <= fireDis)
            {
                nowTime = nowTime + Time.deltaTime;
                if (nowTime >+ fireOffsetTime)
                {
                    Fire();
                    nowTime = 0;
                }
            }
        }
        #endregion

    }
    private void RandomPos()
    {
        if(randomPos.Length == 0)
            return;
        int index = Random.Range(0, randomPos.Length);
        targetPos = randomPos[index];
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            //�����ӵ�����
            GameObject bulletObj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            //��ȡ�ӵ�������صĽű�
            BulletObj bulletTarget = bulletObj.GetComponent<BulletObj>();
            bulletTarget.SetOwner(this);
        }
        
        
    }

    public override void Dead()
    {
        base.Dead();
        //�ƶ�����������ʱ����Ҫ�ӷ�
        GamePanel.Instance.UpdateScore(10);
    }

    //��������е���Ѫ��UI�ĵĻ���  �Ҿ��ú������Խ����˵�Ѫ������Ū��һ���ӿڡ�
    private void OnGUI()
    {
        if (showTime > 0)
        {
            showTime -= Time.deltaTime;
            //��ͼ��Ѫ��
            //1.�ѹ��ﵱǰλ��  ת����  ��Ļλ��
            //��������ṩ��API  ���Խ���������  תΪ  ��Ļ����  ����Z���Ǻ����,���Ը���z����Ѫ������ԶС��Ч��
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

            //2.��Ļλ��  ת����  GUIλ��
            //֪ʶ�㣺��εõ���ǰ��Ļ�ĸ�
            screenPos.y = Screen.height - screenPos.y;

            //Ȼ���ٻ���
            //֪ʶ�㣺GUI�е�  ͼƬ����

            //��ͼ
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            GUI.DrawTexture(maxHpRect, maxHpBK);

            //����Ѫ�������Ѫ���İٷֱ�  ���������
            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 50;
            hpRect.width = (float)hp / maxHp * 100f;
            hpRect.height = 15;
            GUI.DrawTexture(hpRect, hpBK);
            //DrawHeathBar(maxHp, hp, maxHpRect, hpRect, maxHpBK, hpBK, this.transform.position);//�ӿڲ�������ʹ�õ�
        }
        
    }
    //����������ʾѪ��
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 3f;
    }
}
