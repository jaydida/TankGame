using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50f; //子弹移动速度

    //谁发射的子弹
    private TankBaseObj owner;
    //特效对象
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
        //子弹射击到立方体会爆炸
        //同样 子弹射击到  不同阵营的对象也会爆炸
        if (other.CompareTag("Cube") ||
            other.CompareTag("Player") && owner.CompareTag("Monster") ||
            other.CompareTag("Monster") && owner.CompareTag("Player"))
        {
            //判断是否受伤  进行扣血处理
            //得到碰撞到的对象身上  是否有坦克相关脚本  我们用里氏替换原则
            //通过父类来获取   本来物体身上并没有挂这个脚本  这是用里氏替换原则
            TankBaseObj obj = other.GetComponent<TankBaseObj>();
            if (obj != null)
            {
                //造成伤害
                obj.Wound(owner);
            }

            //当子弹销毁时  可以创建一个  爆炸特效
            if (bulletEffectPrefab != null)
            {
                GameObject effect = Instantiate(bulletEffectPrefab, transform.position, transform.rotation);
                //音效的音量和开关
                effect.GetComponent<AudioSource>().volume = GameDataMgr.Instance.musicData.soundValue;
                effect.GetComponent<AudioSource>().mute = !GameDataMgr.Instance.musicData.isOpenSound;
                ////销毁特效
                //Destroy(effect, 1.5f);
            }
            Destroy(gameObject);
            //StartCoroutine(DestroyBulletEffect());


        }
    }

}
