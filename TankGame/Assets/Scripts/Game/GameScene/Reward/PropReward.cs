using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PropType
{
    //�����Ե���������
    Atk,
    Def,
    Hp,
    MaxHp
}

public class PropReward : MonoBehaviour
{
    public E_PropType type = E_PropType.Atk;
    public int changeValue = 2;//�Ӷ�������ֵ

    public GameObject effectReward;

    private void OnTriggerEnter(Collider other)
    {
        //��Ҳ��ܻ�ȡ���Խ���
        if (other.CompareTag("Player"))
        {
            //�õ���Ӧ��ҽű�
            PlayerObj player = other.GetComponent<PlayerObj>();
            //���ݲ�ͬ��������������
            switch (type)
            {
                case E_PropType.Def:
                    player.def += changeValue;
                    break;
                case E_PropType.Atk:
                    player.atk += changeValue;
                    break;
                case E_PropType.Hp:
                    player.hp += changeValue;
                    if(player.hp > player.maxHp)
                    {
                        player.hp = player.maxHp;
                    }
                    //����Ѫ��
                    GamePanel.Instance.UpdateHp(player.maxHp, player.hp);
                    break;
                case E_PropType.MaxHp:
                    player.maxHp += changeValue;
                    //����Ѫ��
                    GamePanel.Instance.UpdateHp(player.maxHp, player.hp);
                    break;
            }
            //������Ч
            if (effectReward != null)
            {
                GameObject effect = Instantiate(effectReward, transform.position, transform.rotation);
                //��Ч�������Ϳ���
                effect.GetComponent<AudioSource>().volume = GameDataMgr.Instance.musicData.soundValue;
                effect.GetComponent<AudioSource>().mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }

            Destroy(gameObject);
        }

    }
}
