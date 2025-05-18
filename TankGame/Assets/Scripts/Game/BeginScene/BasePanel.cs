using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//where T :classԼ��TΪ��
public class BasePanel<T> : MonoBehaviour where T :class
{
    private static T instance;
    public static T Instance => instance;

    private void Awake()
    {
        //��Awake�г�ʼ����ԭ�� ��
        //�������Ľű�  �ڳ�����  �϶�ֻ�����һ��
        //��ô���ǿ���������ű����������ں�����Awake��
        //ֱ�Ӽ�¼������ Ψһ������ű���
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
