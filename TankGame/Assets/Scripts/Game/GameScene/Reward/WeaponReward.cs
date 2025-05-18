using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    //�ж�����������  ����Ԥ����
    public GameObject[] weaponObj;

    public GameObject effectReward;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //������л�����
            int index = Random.Range(0, weaponObj.Length);
            //weaponObj[index];
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.ChangeWeapon(weaponObj[index]);

            //������Ч
            if (effectReward != null)
            {
                GameObject effect = Instantiate(effectReward, transform.position, transform.rotation);
                //��Ч�������Ϳ���
                effect.GetComponent<AudioSource>().volume = GameDataMgr.Instance.musicData.soundValue;
                effect.GetComponent<AudioSource>().mute = !GameDataMgr.Instance.musicData.isOpenSound;
            }

            //����һ�ȡ���Ƴ��Լ�
            Destroy(gameObject);
        }
    }
}
