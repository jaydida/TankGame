using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// �Զ����ѡ�� �ؼ�
/// </summary>
public class CustomGUIToggle : CustomGUIControl
{
    public bool isSel;
    private bool isOldSel;//��һ�ε�״̬

    //����Ҫ�õĻ����޷ǵõ�����ű����õ�����¼���Ҳ���ǳ�Ա�����������¼�����Ӻ���������
    public event UnityAction<bool> changeValue;
    protected override void StyleOffDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content);

        //ֻ����״̬�ı�ʱ�Ż�ִ�У������ϳ���Ҳ��Լ������
        if (isSel != isOldSel)
        {
            changeValue?.Invoke(isSel);///�����Ǵ���Ĳ�����
            isOldSel = isSel;
        }


    }

    protected override void StyleOnDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content, style);

        //ֻ����״̬�ı�ʱ�Ż�ִ�У������ϳ���Ҳ��Լ������
        if (isSel != isOldSel)
        {
            changeValue?.Invoke(isSel);
            isOldSel = isSel;
        }
    }
}
