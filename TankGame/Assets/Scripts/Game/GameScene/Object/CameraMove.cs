using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //С��ͼ����������Ŀ��
    public Transform targetPlayer; // Ŀ������
    public float CameraHeight = 10; // ������߶�

    public Vector3 targetPos; // Ŀ��λ��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //������ƶ�  ��÷��뵽lateupdate�� ��Ϊ��֮�� ��Ҫ��һЩ����
    // Update is called once per frame
    void LateUpdate()
    {
        if (targetPlayer == null)
        {
            return;
        }
        //x z �����һ��  y�Լ�����
        targetPos.x = targetPlayer.transform.position.x; // ��ȡĿ�������λ��
        targetPos.y = CameraHeight; // ����������߶�
        targetPos.z = targetPlayer.transform.position.z ; // ����������߶�
        transform.position = targetPos; // ����������ƶ�
    }
}
