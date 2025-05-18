using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    //用于实例化的子弹对象
    public GameObject bullet;

    //外部觉得到底有几个发射位置
    public Transform[] shootPos;

    //武器拥有者
    public TankBaseObj owner;

    //设置拥有者
    public void SetOwner(TankBaseObj owner)
    {
        this.owner = owner;
    }

    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            //实例化子弹
            GameObject bulletObj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            
            //控制子弹做什么
            BulletObj bulletTarget = bulletObj.GetComponent<BulletObj>();
            bulletTarget.SetOwner(owner);

        }
    }
}
