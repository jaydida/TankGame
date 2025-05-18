using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;//武器对象

    public Transform weaponPos;//武器位置


    // Update is called once per frame
    void Update()
    {
        //1. ws键 控制 前进后退
        //1.transform 位移
        //2. Input 轴向输入检测
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));

        //3. ad键 控制 左右转
        transform.Rotate(Vector3.up * roundSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));//沿着某个轴转

        //4.鼠标左右 控制  炮台旋转
        tankHead.transform.Rotate(Vector3.up * headRoundSpeed * Time.deltaTime * Input.GetAxis("Mouse X"));//沿着某个轴转

        //5. 鼠标左键开火
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public override void Fire()
    {
        if(nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }

    public override void Dead()
    {
        //这里不执行玩家父类的Dead函数  因为  玩家坦克  摄像机是它的子对象  如果执行父类的Dead函数
        //会把玩家坦克从场景上移除  那么间接的移除了摄像机
        //base.Dead();
        //暂停游戏
        Time.timeScale = 0f;
        //调出失败界面
        FailurePanel.Instance.ShowPanel();
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //更新主面板血条
        GamePanel.Instance.UpdateHp(maxHp, hp);
    }
    /// <summary>
    /// 切换武器
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        if(nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }

        //切换武器  实例化武器对象  weaponPos, false  设置为父对象的子对象  保留缩放大小
        GameObject weaponObj = Instantiate(weapon, weaponPos, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        //设置武器的拥有者
        nowWeapon.SetOwner(this);

    }
}
