using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    //�Զ���ת�Ѿ�ͨ�����ؽű��ķ�ʽʵ����  һ��ר�Ź���ת�Ľű�

    //�������
    //һ�����ʱ��
    public float fireOffsetTime = 1.0f;
    private float nowTime = 0.0f;

    //����λ��
    public Transform[] shootPos;

    //�ӵ�Ԥ����  ����
    public GameObject bulletObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime > fireOffsetTime)
        {
            Fire();
            nowTime = 0.0f;
        }
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            //�����ӵ�
            GameObject bullet = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            //��ȡ�ӵ��ű�
            BulletObj bulletTarget = bullet.GetComponent<BulletObj>();
            bulletTarget.SetOwner(this);
        }
    }

    public override void Dead()
    {
        //ʲô���ݶ���д
        //Ŀ�ľ��� �����  �̶������̹��  ���ᱻ����
    }
}
