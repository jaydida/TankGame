using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    //������ЧԤ�������
    public GameObject[] rewardObjects;

    //����������Ч  Ԥ�������
    public GameObject deadEffect;
    private void OnTriggerEnter(Collider other)
    {
        //1.���Լ����ӵ�  Ӧ������
        //ֻ��Ҫ�����ӵı�ǩ��ΪCube�����ˡ�֮ǰ�ӵ��߼����о�һ����������� Cube  �����Լ����߼�

        //2.���Լ� Ӧ�ô���  ��������������߼�
        int rangeInt = Random.Range(0, 100);
        //�ٷ�֮��ʮ�ļ��ʴ���һ������
        if (rangeInt < 50)
        {
            //�������һ������Ԥ�����ڵ�ǰλ��
            rangeInt = Random.Range(0, rewardObjects.Length);
            //���ڵ�ǰ�������ڵ�λ��
            Instantiate(rewardObjects[rangeInt], transform.position, transform.rotation);

        }
        GameObject effect = Instantiate(deadEffect, transform.position, transform.rotation);
        //��Ч�������Ϳ���
        effect.GetComponent<AudioSource>().volume = GameDataMgr.Instance.musicData.soundValue;
        effect.GetComponent<AudioSource>().mute = !GameDataMgr.Instance.musicData.isOpenSound;

        Destroy(gameObject);

    }
}
