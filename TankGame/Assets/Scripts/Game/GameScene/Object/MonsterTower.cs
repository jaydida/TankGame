using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    //自动旋转已经通过挂载脚本的方式实现了  一个专门管旋转的脚本

    //间隔开火
    //一个间隔时间
    public float fireOffsetTime = 1.0f;
    private float nowTime = 0.0f;

    //发射位置
    public Transform[] shootPos;

    //子弹预设体  关联
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
            //创建子弹
            GameObject bullet = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            //获取子弹脚本
            BulletObj bulletTarget = bullet.GetComponent<BulletObj>();
            bulletTarget.SetOwner(this);
        }
    }

    public override void Dead()
    {
        //什么内容都不写
        //目的就是 让这个  固定不变的坦克  不会被销毁
    }
}
