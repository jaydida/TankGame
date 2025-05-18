using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    //����ʵ�������ӵ�����
    public GameObject bullet;

    //�ⲿ���õ����м�������λ��
    public Transform[] shootPos;

    //����ӵ����
    public TankBaseObj owner;

    //����ӵ����
    public void SetOwner(TankBaseObj owner)
    {
        this.owner = owner;
    }

    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            //ʵ�����ӵ�
            GameObject bulletObj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            
            //�����ӵ���ʲô
            BulletObj bulletTarget = bulletObj.GetComponent<BulletObj>();
            bulletTarget.SetOwner(owner);

        }
    }
}
