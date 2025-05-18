using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//该脚本的使用，需要先拖入已经实例化的多选框。
public class CustomGUIToggleGroup : MonoBehaviour
{
    public CustomGUIToggle[] toggles;

    //记录上一次为true的toggle
    private CustomGUIToggle frontTurtog;

    // Start is called before the first frame update
    void Start()
    {
        if(toggles.Length == 0)
        {
            return;
        }

        //通过遍历 来为多个 多选框 添加 监听事件函数
        //在函数中做处理
        //当一个为true时，另外两个变成false
        for (int i = 0; i < toggles.Length; i++)
        {
            CustomGUIToggle toggle = toggles[i];
            toggle.changeValue += (value) => 
            {
                //如果传入的值为true  需要把另外的设置为false
                if (value)
                {
                    frontTurtog = toggle;//记录上一次为true的toggle

                    for (int j = 0; j < toggles.Length; j++)
                    {
                        if (toggles[j] != toggle)//这里是用的lambda表达式，这里有一个闭包，改变了变量的生命周期，所以不能直接比较 j 与 i
                        {
                            toggles[j].isSel = false;
                        }
                    }
                }
                //判断这次设置为false的toggle是不是上次为true的toggle，是的话就不能设置为false，看来这里需要必须有一个为true的toggle
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
