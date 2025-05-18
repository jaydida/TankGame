using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class HealthBarBase : MonoBehaviour,IHPBar
{
    public virtual void DrawHeathBar(float maxHp, float hp, Rect maxHpRect, Rect hpRect, Texture maxHpBK, Texture hpBK, Vector3 worldPoint)
    {
        //画图画血条
        //1.把怪物当前位置  转换成  屏幕位置
        //摄像机里提供了API  可以将世界坐标  转为  屏幕坐标  其中Z轴是横截面,可以根据z做出血条近大远小的效果
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPoint);

        //2.屏幕位置  转换成  GUI位置
        //知识点：如何得到当前屏幕的高
        screenPoint.y =Screen.height - screenPoint.y;

        //然后再绘制
        //知识点：GUI中的  图片绘制
        //底图
        maxHpRect.x = screenPoint.x - 50;
        maxHpRect.y = screenPoint.y - 50;
        maxHpRect.width = 100;
        maxHpRect.height = 15;
        GUI.DrawTexture(maxHpRect, maxHpBK);

        //根据血量和最大血量的百分比  决定画多宽
        hpRect.x = screenPoint.x - 50;
        hpRect.y = screenPoint.y - 50;
        hpRect.width = (float)hp / maxHp * 100f;
        hpRect.height = 15;
        GUI.DrawTexture(hpRect, hpBK);

    }


}
