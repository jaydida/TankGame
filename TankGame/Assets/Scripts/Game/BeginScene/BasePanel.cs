using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//where T :class约束T为类
public class BasePanel<T> : MonoBehaviour where T :class
{
    private static T instance;
    public static T Instance => instance;

    private void Awake()
    {
        //在Awake中初始化的原因 是
        //我们面板的脚本  在场景上  肯定只会挂载一次
        //那么我们可以在这个脚本的生命周期函数的Awake中
        //直接记录场景上 唯一的这个脚本，
        instance = this as T;
    }

    public virtual void ShowPanel()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HidePanel()
    {
        this.gameObject.SetActive(false);
    }
}
