using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ͨ��һ��������  ʵ������������  ������ʹ�õ�����[ExecuteAlways]
/// �����Ӷ���ִ�е�˳��Ҳ��ͨ�������������ʵ�ֵģ����ҽ�ԭ��GUIControl�����л��Ƶ�OnGui�����ĳ�һ�����ƺ�����ͨ���ⲿ���û��ơ�
/// </summary>
[ExecuteAlways]//�༭ģʽ��Ҳ��ִ��
public class CustomGUIRoot : MonoBehaviour
{
    //���ڴ洢  �Ӷ���  ����GUI�ؼ�������
    private CustomGUIControl[] allControls;


    // Start is called before the first frame update
    void Start()
    {
        //����Ҫ��û�еĻ�  ��gameģʽ��  ��û��ִ�и���䣬Ҳ��allControlsû�л�ø�ֵ��
        allControls = GetComponentsInChildren<CustomGUIControl>();
    }

    //ͬһ�����Ӷ���ؼ�������
    private void OnGUI()
    {
        //ͨ��ÿһ�λ���֮ǰ  �õ������Ӷ���ؼ���  ����ű�
        //������ �˷����� ��Ϊÿ�� gui��������ȡ���е�  �ؼ���Ӧ�Ľű�
        //�༭״̬��  �Ż�һֱִ�У�������Start������Ҳ����  ��������Ҫ�����ж�
        //Application.isPlaying��Ϸ�Ƿ�������
        //if (!Application.isPlaying)
        //{
        //    //��ȡ�����Ӷ���ؼ��ĸ���ű�
        //    allControls = GetComponentsInChildren<CustomGUIControl>();
        //}
        //�������game״̬�£����ȡ�����ˣ������Ȳ�ʹ�ø÷���//TODO
        allControls = GetComponentsInChildren<CustomGUIControl>();
        //����ÿһ���ؼ�  ����  ִ�л���
        for (int i = 0; i< allControls.Length; i++)
        {
            allControls[i].DrawGUI();
        }
    }
}
