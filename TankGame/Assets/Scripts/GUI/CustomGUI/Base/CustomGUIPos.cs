using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 对齐方式枚举
/// </summary>
public enum E_Alignment_Type
{
    Up, Down, Left, Right, Center, LeftUp, RightUp, LeftDown, RightDown
}

/// <summary>
/// 该类  是用来表示位置  计算位置相关信息的  不需要继承monobehaviour
/// </summary>
[System.Serializable]
public class CustomGUIPos 
{
    //处理控件位置相关的内容
    //完成分辨率自适应的相关计算

    //该位置信息  会用来返回给外部  用于绘制控件
    //需要对它进行  计算  就是那个九宫格
    //控件坐标计算公式  =  相对屏幕位置  +  中心点偏移位置  +  偏移位置
    private Rect pos = new Rect(0, 0, 100, 100);

    //屏幕九宫格对齐方式
    public E_Alignment_Type screen_Alignment_Type = E_Alignment_Type.Center;
    //控件中心对齐方式
    public E_Alignment_Type control_Center_Alignment_Type = E_Alignment_Type.Center;
    //偏移位置
    public Vector2 offestPos;
    //宽高
    public float width = 100;
    public float height = 50;

    //用于计算的  中心点  成员变量
    private Vector2 centerPos;

    /// <summary>
    /// 得到  最终绘制的位置 和 宽高。
    /// </summary>
    public Rect Pos 
    {
        get 
        { 
            //进行计算
            //计算中心点偏移
            CalcCenterPos();
            //计算相对屏幕坐标点
            CalcPos();
            //宽高直接赋值   返回给外部   别人直接使用来绘制控件
            pos.width = width;
            pos.height = height;

            return pos; 
        } 
    }
    /// <summary>
    /// 计算中心点偏移的方法，每一个控件的
    /// </summary>
    private void CalcCenterPos()
    {
        switch (control_Center_Alignment_Type)
        {
            case E_Alignment_Type.Left:
                centerPos.x = 0;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Right:
                centerPos.x = -width;
                centerPos.y = -height / 2;
                break;
            case E_Alignment_Type.Center:
                centerPos.x = -width / 2;
                centerPos.y = -height / 2 ;
                break;
            case E_Alignment_Type.LeftUp:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.RightUp:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Up:
                centerPos.x = -width / 2;
                centerPos.y = 0;
                break;
            case E_Alignment_Type.Down:
                centerPos.x = -width / 2;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.LeftDown:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_Alignment_Type.RightDown:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
        }
    }

    /// <summary>
    /// 计算最终相对坐标位置的方法
    /// </summary>
    private void CalcPos()
    {
        switch (screen_Alignment_Type)
        {
            case E_Alignment_Type.Left:
                pos.x = centerPos.x + offestPos.x;
                pos.y = Screen.height / 2 + centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.Right:
                pos.x = Screen.width + centerPos.x - offestPos.x;
                pos.y = Screen.height / 2 + centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.Center:
                pos.x = Screen.width / 2 + centerPos.x + offestPos.x;
                pos.y = Screen.height / 2 + centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.LeftUp:
                pos.x = centerPos.x + offestPos.x;
                pos.y = centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.RightUp:
                pos.x = Screen.width + centerPos.x - offestPos.x;
                pos.y = centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.Up:
                pos.x = Screen.width / 2 + centerPos.x + offestPos.x;
                pos.y = 0 + centerPos.y + offestPos.y;
                break;
            case E_Alignment_Type.Down:
                pos.x = Screen.width / 2 + centerPos.x + offestPos.x;
                pos.y = Screen.height + centerPos.y - offestPos.y;
                break;
            case E_Alignment_Type.LeftDown:
                pos.x = centerPos.x + offestPos.x;
                pos.y = Screen.height + centerPos.y - offestPos.y;
                break;
            case E_Alignment_Type.RightDown:
                pos.x = Screen.width + centerPos.x - offestPos.x;
                pos.y = Screen.height + centerPos.y - offestPos.y;
                break;

        }
    }
}
