using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 自定义多选框 控件
/// </summary>
public class CustomGUIToggle : CustomGUIControl
{
    public bool isSel;
    private bool isOldSel;//上一次的状态

    //外面要用的话，无非得到这个脚本，得到这个事件（也就是成员变量），往事件里添加函数就行了
    public event UnityAction<bool> changeValue;
    protected override void StyleOffDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content);

        //只有在状态改变时才会执行，即符合常理，也节约了性能
        if (isSel != isOldSel)
        {
            changeValue?.Invoke(isSel);///这里是传入的参数。
            isOldSel = isSel;
        }


    }

    protected override void StyleOnDraw()
    {
        isSel = GUI.Toggle(guiPos.Pos, isSel, content, style);

        //只有在状态改变时才会执行，即符合常理，也节约了性能
        if (isSel != isOldSel)
        {
            changeValue?.Invoke(isSel);
            isOldSel = isSel;
        }
    }
}
