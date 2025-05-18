using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    //继承monobehaviour 不能直接new一个对象出来
    private static BKMusic instance;
    public static BKMusic Instance => instance;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        //获取数据
        //开启或者关闭背景音乐
        ChangeValue(GameDataMgr.Instance.musicData.bkValue);
        ChangeOpen(GameDataMgr.Instance.musicData.isOpenBK);

    }
    /// <summary>
    /// 改变背景音乐大小
    /// </summary>
    /// <param name="value"></param>
    public void ChangeValue(float value)
    {
        audioSource.volume = value;
    }
    /// <summary>
    /// 开关背景音乐
    /// </summary>
    /// <param name="isOpen"></param>
    public void ChangeOpen(bool isOpen)
    {
        //开启就是不禁音
        //没有开启就是禁音
        audioSource.mute = !isOpen;
    }
}
