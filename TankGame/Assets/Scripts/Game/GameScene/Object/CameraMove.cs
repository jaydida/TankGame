using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //小地图摄像机看向的目标
    public Transform targetPlayer; // 目标物体
    public float CameraHeight = 10; // 摄像机高度

    public Vector3 targetPos; // 目标位置

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //摄像机移动  最好放入到lateupdate中 因为这之间 需要做一些处理
    // Update is called once per frame
    void LateUpdate()
    {
        if (targetPlayer == null)
        {
            return;
        }
        //x z 和玩家一样  y自己设置
        targetPos.x = targetPlayer.transform.position.x; // 获取目标物体的位置
        targetPos.y = CameraHeight; // 设置摄像机高度
        targetPos.z = targetPlayer.transform.position.z ; // 设置摄像机高度
        transform.position = targetPos; // 设置摄像机移动
    }
}
