using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ýű���ʹ�ã���Ҫ�������Ѿ�ʵ�����Ķ�ѡ��
public class CustomGUIToggleGroup : MonoBehaviour
{
    public CustomGUIToggle[] toggles;

    //��¼��һ��Ϊtrue��toggle
    private CustomGUIToggle frontTurtog;

    // Start is called before the first frame update
    void Start()
    {
        if(toggles.Length == 0)
        {
            return;
        }

        //ͨ������ ��Ϊ��� ��ѡ�� ��� �����¼�����
        //�ں�����������
        //��һ��Ϊtrueʱ�������������false
        for (int i = 0; i < toggles.Length; i++)
        {
            CustomGUIToggle toggle = toggles[i];
            toggle.changeValue += (value) => 
            {
                //��������ֵΪtrue  ��Ҫ�����������Ϊfalse
                if (value)
                {
                    frontTurtog = toggle;//��¼��һ��Ϊtrue��toggle

                    for (int j = 0; j < toggles.Length; j++)
                    {
                        if (toggles[j] != toggle)//�������õ�lambda���ʽ��������һ���հ����ı��˱������������ڣ����Բ���ֱ�ӱȽ� j �� i
                        {
                            toggles[j].isSel = false;
                        }
                    }
                }
                //�ж��������Ϊfalse��toggle�ǲ����ϴ�Ϊtrue��toggle���ǵĻ��Ͳ�������Ϊfalse������������Ҫ������һ��Ϊtrue��toggle
                else
                {
                    if (toggle == frontTurtog)
                    {
                        toggle.isSel = true;
                    }
                }

            };
        }
    }

    
}
