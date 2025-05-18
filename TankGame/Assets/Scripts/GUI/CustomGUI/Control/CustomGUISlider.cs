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
/// �϶����ؼ�
/// </summary>
public class CustomGUISlider : CustomGUIControl
{
    //��Сֵ
    public float minValue = 0;
    //���ֵ
    public float maxValue = 1;
    //��ǰֵ
    public float nowValue = 0.5f;
    //ˮƽ������ֱ����ʽ
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
