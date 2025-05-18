using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIControl
{
    //�ṩ���ⲿ ������Ӧ  ��ť������¼� ֻҪ���ⲿ��������Ӧ����  �Ǿͻ�ִ�С�
    public event UnityAction clickEvent;
    protected override void StyleOffDraw()
    {
        if(GUI.Button(guiPos.Pos, content))
        {
            //?�ж��Ƿ�Ϊ�գ��յĻ��Ͳ�ִ��
            clickEvent?.Invoke();
        }
    }

    protected override void StyleOnDraw()
    {
        if (GUI.Button(guiPos.Pos, content, style))
        {
            clickEvent?.Invoke();
        }
    }
}
