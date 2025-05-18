using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �Զ���ͼƬ����
/// </summary>
public class CustomGUITexture : CustomGUIControl
{
    //ͼƬ������ģʽ
    public ScaleMode scaleMode = ScaleMode.StretchToFill;
    protected override void StyleOffDraw()
    {
        GUI.DrawTexture(guiPos.Pos, content.image, scaleMode);
    }

    protected override void StyleOnDraw()
    {
        //�������û��style�����Կ�������һ����
        GUI.DrawTexture(guiPos.Pos, content.image, scaleMode);
    }
}
