using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50f; //�ӵ��ƶ��ٶ�

    //˭������ӵ�
    private TankBaseObj owner;
    //��Ч����
    public GameObject bulletEffectPrefab;
    public void SetOwner(TankBaseObj owner)
    {
        this.owner = owner;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�ӵ������������ᱬը
        //ͬ�� �ӵ������  ��ͬ��Ӫ�Ķ���Ҳ�ᱬը
        if (other.CompareTag("Cube") ||
            other.CompareTag("Player") && owner.CompareTag("Monster") ||
            other.CompareTag("Monster") && owner.CompareTag("Player"))
        {
            //�ж��Ƿ�����  ���п�Ѫ����
            //�õ���ײ���Ķ�������  �Ƿ���̹����ؽű�  �����������滻ԭ��
            //ͨ����������ȡ   �����������ϲ�û�й�����ű�  �����������滻ԭ��
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if (obj != null)
            {
                //����˺�
                obj.Wound(owner);
            }

            //���ӵ�����ʱ  ���Դ���һ��  ��ը��Ч
            if (bulletEffectPrefab != null)
            {
                GameObject effect = Instantiate(bulletEffectPrefab, transform.position, transform.rotation);
                //��Ч�������Ϳ���
                effect.GetComponent<AudioSource>().volume = GameDataMgr.Instance.musicData.soundValue;
                effect.GetComponent<AudioSource>().mute = !GameDataMgr.Instance.musicData.isOpenSound;
                ////������Ч
                //Destroy(effect, 1.5f);
            }
            Destroy(gameObject);
            //StartCoroutine(DestroyBulletEffect());


        }
    }

}
