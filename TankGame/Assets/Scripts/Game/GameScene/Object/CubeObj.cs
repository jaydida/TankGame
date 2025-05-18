using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    //奖励特效预设体关联
    public GameObject[] rewardObjects;

    //创建死亡特效  预设体关联
    public GameObject deadEffect;
    private void OnTriggerEnter(Collider other)
    {
        //1.打到自己的子弹  应该销毁
        //只需要将箱子的标签改为Cube就行了。之前子弹逻辑当中就一个处理过打中 Cube  销毁自己的逻辑

        //2.打到自己 应该处理  随机创建奖励的逻辑
        int rangeInt = Random.Range(0, 100);
        //百分之五十的几率创建一个奖励
        if (rangeInt < 50)
        {
            //随机创建一个奖励预设体在当前位置
            rangeInt = Random.Range(0, rewardObjects.Length);
            //放在当前箱子所在的位置
            Instantiate(rewardObjects[rangeInt], transform.position, transform.rotation);

        }
        GameObject effect = Instantiate(deadEffect, transform.position, transform.rotation);
        //音效的音量和开关
        effect.GetComponent<AudioSource>().volume = GameDataMgr.Instance.musicData.soundValue;
        effect.GetComponent<AudioSource>().mute = !GameDataMgr.Instance.musicData.isOpenSound;

        Destroy(gameObject);

    }
}
