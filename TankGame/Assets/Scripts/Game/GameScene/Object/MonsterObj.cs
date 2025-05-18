using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObj : TankBaseObj
{
    //1.要让坦克在两个点之间来回移动
    //当前的目标点
    private Transform targetPos;
    //随机用的点 外面去关联
    public Transform[] randomPos;
    //2.坦克要一直盯着自己的目标
    public Transform lookAtTarget;
    //3.当目标到达一定范围内过后  间隔一段时间  攻击一下目标
    //开火距离  但小于这个距离时  就会主动攻击
    public float fireDis = 5;
    //为了避免太难  加一个攻击间隔时间
    public float fireOffsetTime = 1f;
    private float nowTime;

    //子弹对象  BulletObj不是子弹对象 只是子弹对象挂载的一个自定义脚本
    public GameObject bullet;
    //子弹发射点
    public Transform[] shootPos;

    //两张血条图  外部关联
    public Texture maxHpBK;
    public Texture hpBK;

    //私有的  不new一下  除非结构体要不然报错。
    private Rect maxHpRect ;
    private Rect hpRect;

    //敌人血条显示时间
    private float showTime;


    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        #region 多个点之间的随机移动逻辑
        //看向自己的目标点
        this.transform.LookAt(targetPos);
        //不停的向自己的面朝向位移
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //知识点  Vector3里面有一个得到两个点之间距离的方法
        //当距离过小时  认为到达了目的地  重新随机一个点
        //物体移动是一段一段离散的移动
        if (Vector3.Distance(transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }
        #endregion

        #region 看向自己的目标
        if (lookAtTarget != null) 
        {
            tankHead.transform.LookAt(lookAtTarget);
            //当自己和目标对象的距离  小于等于  配置的  开火距离时
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
            //创建子弹对象
            GameObject bulletObj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            //获取子弹对象挂载的脚本
            BulletObj bulletTarget = bulletObj.GetComponent<BulletObj>();
            bulletTarget.SetOwner(this);
        }
        
        
    }

    public override void Dead()
    {
        base.Dead();
        //移动怪物死亡的时候需要加分
        GamePanel.Instance.UpdateScore(10);
    }

    //在这里进行敌人血条UI的的绘制  我觉得后续可以将敌人的血条绘制弄成一个接口。
    private void OnGUI()
    {
        if (showTime > 0)
        {
            showTime -= Time.deltaTime;
            //画图画血条
            //1.把怪物当前位置  转换成  屏幕位置
            //摄像机里提供了API  可以将世界坐标  转为  屏幕坐标  其中Z轴是横截面,可以根据z做出血条近大远小的效果
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);

            //2.屏幕位置  转换成  GUI位置
            //知识点：如何得到当前屏幕的高
            screenPos.y = Screen.height - screenPos.y;

            //然后再绘制
            //知识点：GUI中的  图片绘制

            //底图
            maxHpRect.x = screenPos.x - 50;
            maxHpRect.y = screenPos.y - 50;
            maxHpRect.width = 100;
            maxHpRect.height = 15;
            GUI.DrawTexture(maxHpRect, maxHpBK);

            //根据血量和最大血量的百分比  决定画多宽
            hpRect.x = screenPos.x - 50;
            hpRect.y = screenPos.y - 50;
            hpRect.width = (float)hp / maxHp * 100f;
            hpRect.height = 15;
            GUI.DrawTexture(hpRect, hpBK);
            //DrawHeathBar(maxHp, hp, maxHpRect, hpRect, maxHpBK, hpBK, this.transform.position);//接口不是这样使用的
        }
        
    }
    //加入受伤显示血条
    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        showTime = 3f;
    }
}
