using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    //有多个用于随机的  武器预设体
    public GameObject[] weaponObj;

    public GameObject effectReward;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //让玩家切换武器
            int index = Random.Range(0, weaponObj.Length);
            //weaponObj[index];
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weaponObj[index]);

            //播放特效
            if (effectReward != null)
            {
                GameObject effect = Instantiate(effectReward, transform.position, transform.rotation);
                //音效的音量和开关
                effect.GetComponent<AudioSource>().volume = GameDataMgr.Instance.musicData.soundValue;
                effect.GetComponent<AudioSource>().mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }

            //被玩家获取后移除自己
            Destroy(gameObject);
        }
    }
}
