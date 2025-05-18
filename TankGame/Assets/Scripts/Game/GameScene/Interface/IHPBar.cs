using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public interface IHPBar 
{
    void DrawHeathBar(float maxHp, float hp, Rect maxHpRect, Rect hpRect, Texture maxHpBK, Texture hpBK, Vector3 worldPoint);
}
