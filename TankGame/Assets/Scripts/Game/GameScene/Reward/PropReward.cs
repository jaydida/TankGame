using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PropType
{
    //加属性的四种类型
    Atk,
    Def,
    Hp,
    MaxHp
}

public class PropReward : MonoBehaviour
{
    public E_PropType type = E_PropType.Atk;
    public int changeValue = 2;//加多少属性值

    public GameObject effectReward;

    private void OnTriggerEnter(Collider other)
    {
        //玩家才能获取属性奖励
        if (other.CompareTag("Player"))
        {
            //得到对应玩家脚本
            PlayerObj player = other.GetComponent<PlayerObj>();
            //根据不同的类型来加属性
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
                    //更新血条
                    GamePanel.Instance.UpdateHp(player.maxHp, player.hp);
                    break;
                case E_PropType.MaxHp:
                    player.maxHp += changeValue;
                    //更新血条
                    GamePanel.Instance.UpdateHp(player.maxHp, player.hp);
                    break;
            }
            //创建特效
            if (effectReward != null)
            {
                GameObject effect = Instantiate(effectReward, transform.position, transform.rotation);
                //音效的音量和开关
                effect.GetComponent<AudioSource>().volume = GameDataMgr.Instance.musicData.soundValue;
                effect.GetComponent<AudioSource>().mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }

            Destroy(gameObject);
        }

    }
}
