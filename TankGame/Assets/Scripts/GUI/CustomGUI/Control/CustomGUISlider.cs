using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum E_Slider_Type
{
    Horizontal,
    Vertical
}
/// <summary>
/// 拖动条控件
/// </summary>
public class CustomGUISlider : CustomGUIControl
{
    //最小值
    public float minValue = 0;
    //最大值
    public float maxValue = 1;
    //当前值
    public float nowValue = 0.5f;
    //水平还是竖直的样式
    public E_Slider_Type sliderType = E_Slider_Type.Horizontal;

    public GUIStyle styleThumb;

    public event UnityAction<float> changeValue;

    private float oldValue = 0.5f;

    protected override void StyleOffDraw()
    {
        switch (sliderType)
        {
            case E_Slider_Type.Horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
            case E_Slider_Type.Vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue);
                break;
        }

        if (oldValue != nowValue)
        {
            changeValue?.Invoke(nowValue);
            oldValue = nowValue;
        }

    }

    protected override void StyleOnDraw()
    {
        switch (sliderType)
        {
            case E_Slider_Type.Horizontal:
                nowValue = GUI.HorizontalSlider(guiPos.Pos, nowValue, minValue, maxValue, style, styleThumb);
                break;
            case E_Slider_Type.Vertical:
                nowValue = GUI.VerticalSlider(guiPos.Pos, nowValue, minValue, maxValue, style, styleThumb);
                break;
        }
        if (oldValue != nowValue)
        {
            changeValue?.Invoke(nowValue);
            oldValue = nowValue;
        }
    }
}
