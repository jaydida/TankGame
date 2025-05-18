using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;//��������

    public Transform weaponPos;//����λ��


    // Update is called once per frame
    void Update()
    {
        //1. ws�� ���� ǰ������
        //1.transform λ��
        //2. Input ����������
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));

        //3. ad�� ���� ����ת
        transform.Rotate(Vector3.up * roundSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));//����ĳ����ת

        //4.������� ����  ��̨��ת
        tankHead.transform.Rotate(Vector3.up * headRoundSpeed * Time.deltaTime * Input.GetAxis("Mouse X"));//����ĳ����ת

        //5. ����������
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
        //���ﲻִ����Ҹ����Dead����  ��Ϊ  ���̹��  ������������Ӷ���  ���ִ�и����Dead����
        //������̹�˴ӳ������Ƴ�  ��ô��ӵ��Ƴ��������
        //base.Dead();
        //��ͣ��Ϸ
        Time.timeScale = 0f;
        //����ʧ�ܽ���
        FailurePanel.Instance.ShowPanel();
    }

    public override void Wound(TankBaseObj other)
    {
        base.Wound(other);
        //���������Ѫ��
        GamePanel.Instance.UpdateHp(maxHp, hp);
    }
    /// <summary>
    /// �л�����
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        if(nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }

        //�л�����  ʵ������������  weaponPos, false  ����Ϊ��������Ӷ���  �������Ŵ�С
        GameObject weaponObj = Instantiate(weapon, weaponPos, false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        //����������ӵ����
        nowWeapon.SetOwner(this);

    }
}
