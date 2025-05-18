using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 自定义图片绘制
/// </summary>
public class CustomGUITexture : CustomGUIControl
{
    //图片的缩放模式
    public ScaleMode scaleMode = ScaleMode.StretchToFill;
    protected override void StyleOffDraw()
    {
        GUI.DrawTexture(guiPos.Pos, content.image, scaleMode);
    }

    protected override void StyleOnDraw()
    {
        //这个玩意没有style，所以可以两个一样。
        GUI.DrawTexture(guiPos.Pos, content.image, scaleMode);
    }
}
