using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIControl
{
    //提供给外部 用于响应  按钮点击的事件 只要在外部给予了响应函数  那就会执行。
    public event UnityAction clickEvent;
    protected override void StyleOffDraw()
    {
        if(GUI.Button(guiPos.Pos, content))
        {
            //?判断是否为空，空的话就不执行
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
