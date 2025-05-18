using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    //坦克的基本属性 攻击 防御 最大生命值 当前生命值
    public int atk;
    public int def;
    public int hp;
    public int maxHp;
    //炮台
    public Transform tankHead;

    //坦克的移动速度 旋转速度 头部旋转速度
    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    //死亡特效 关联对应预设体  死亡的时候  动态创建出来  设置位置即可
    public GameObject deadEffectPrefab;

    /// <summary>
    /// 开火抽象方法  子类重写开火行为
    /// </summary>
    public abstract void Fire();

    public virtual void Wound(TankBaseObj other)
    {
        int damage = other.atk - def;
        if (damage < 0)
        {
            damage = 0;
        }
        //造成伤害
        hp -= damage;
        //死亡判断
        if (hp <= 0)
        {
            //避免hp为负值
            hp = 0;
            //死亡
            Dead();
        }
    }

    public virtual void Dead()
    {
        //死亡
        Destroy(gameObject);
        //死亡的时候  可能所有的坦克 对象  都应该播放一个对象的特效
        if (deadEffectPrefab != null)
        {
            //实例化对象  把位置 角度一起设置
            GameObject effect = Instantiate(deadEffectPrefab, transform.position, transform.rotation);
            //由于该特效对象身上  直接关联了音效  所以我们可以在此处  把音效相关也控制了
            //直接根据现有的数据关于音效的数据 来进行设置

            AudioSource audio = effect.GetComponent<AudioSource>();
            //根据音乐数据  设置音效大小  和是否  播放
            audio.volume = GameDataMgr.Instance.musicData.soundValue;//大小
            audio.mute = !GameDataMgr.Instance.musicData.isOpenSound;//是否播放
            audio.Play();//避免没有勾选Play on Awake 

        }

    }
}
