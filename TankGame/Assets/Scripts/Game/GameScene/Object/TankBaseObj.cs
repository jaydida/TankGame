using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    //̹�˵Ļ������� ���� ���� �������ֵ ��ǰ����ֵ
    public int atk;
    public int def;
    public int hp;
    public int maxHp;
    //��̨
    public Transform tankHead;

    //̹�˵��ƶ��ٶ� ��ת�ٶ� ͷ����ת�ٶ�
    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;

    //������Ч ������ӦԤ����  ������ʱ��  ��̬��������  ����λ�ü���
    public GameObject deadEffectPrefab;

    /// <summary>
    /// ������󷽷�  ������д������Ϊ
    /// </summary>
    public abstract void Fire();

    public virtual void Wound(TankBaseObj other)
    {
        int damage = other.atk - def;
        if (damage < 0)
        {
            damage = 0;
        }
        //����˺�
        hp -= damage;
        //�����ж�
        if (hp <= 0)
        {
            //����hpΪ��ֵ
            hp = 0;
            //����
            Dead();
        }
    }

    public virtual void Dead()
    {
        //����
        Destroy(gameObject);
        //������ʱ��  �������е�̹�� ����  ��Ӧ�ò���һ���������Ч
        if (deadEffectPrefab != null)
        {
            //ʵ��������  ��λ�� �Ƕ�һ������
            GameObject effect = Instantiate(deadEffectPrefab, transform.position, transform.rotation);
            //���ڸ���Ч��������  ֱ�ӹ�������Ч  �������ǿ����ڴ˴�  ����Ч���Ҳ������
            //ֱ�Ӹ������е����ݹ�����Ч������ ����������

            AudioSource audio = effect.GetComponent<AudioSource>();
            //������������  ������Ч��С  ���Ƿ�  ����
            audio.volume = GameDataMgr.Instance.musicData.soundValue;//��С
            audio.mute = !GameDataMgr.Instance.musicData.isOpenSound;//�Ƿ񲥷�
            audio.Play();//����û�й�ѡPlay on Awake 

        }

    }
}
