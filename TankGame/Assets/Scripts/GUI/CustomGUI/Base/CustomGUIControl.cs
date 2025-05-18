using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_Style_OnOff
{
    On,
    Off
}
public abstract class CustomGUIControl : MonoBehaviour
{
    //��ȡ�ؼ��Ĺ�ͬ����
    //λ����Ϣ
    public CustomGUIPos guiPos;
    //��ʾ������Ϣ
    public GUIContent content;
    //�Զ�����ʽ
    public GUIStyle style;
    //�Զ�����ʽ�Ƿ����õĿ��أ�
    public E_Style_OnOff style_OnOff = E_Style_OnOff.Off;

    //�ṩ���ⲿ  ����GUI�ؼ��ķ���
    public void DrawGUI()
    {
        switch(style_OnOff)
        {
            case E_Style_OnOff.On:
                StyleOnDraw();
                break;
            case E_Style_OnOff.Off:
                StyleOffDraw();
                break;
        }
    }
    /// <summary>
    /// �Զ�����ʽ����ʱ�Ļ��Ʒ���
    /// </summary>
    protected abstract void StyleOnDraw();

    /// <summary>
    /// �Զ�����ʽ�ر�ʱ�Ļ��Ʒ���
    /// </summary>
    protected abstract void StyleOffDraw();
    
}
