using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class HealthBarBase : MonoBehaviour,IHPBar
{
    public virtual void DrawHeathBar(float maxHp, float hp, Rect maxHpRect, Rect hpRect, Texture maxHpBK, Texture hpBK, Vector3 worldPoint)
    {
        //��ͼ��Ѫ��
        //1.�ѹ��ﵱǰλ��  ת����  ��Ļλ��
        //��������ṩ��API  ���Խ���������  תΪ  ��Ļ����  ����Z���Ǻ����,���Ը���z����Ѫ������ԶС��Ч��
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPoint);

        //2.��Ļλ��  ת����  GUIλ��
        //֪ʶ�㣺��εõ���ǰ��Ļ�ĸ�
        screenPoint.y =Screen.height - screenPoint.y;

        //Ȼ���ٻ���
        //֪ʶ�㣺GUI�е�  ͼƬ����
        //��ͼ
        maxHpRect.x = screenPoint.x - 50;
        maxHpRect.y = screenPoint.y - 50;
        maxHpRect.width = 100;
        maxHpRect.height = 15;
        GUI.DrawTexture(maxHpRect, maxHpBK);

        //����Ѫ�������Ѫ���İٷֱ�  ���������
        hpRect.x = screenPoint.x - 50;
        hpRect.y = screenPoint.y - 50;
        hpRect.width = (float)hp / maxHp * 100f;
        hpRect.height = 15;
        GUI.DrawTexture(hpRect, hpBK);

    }


}
