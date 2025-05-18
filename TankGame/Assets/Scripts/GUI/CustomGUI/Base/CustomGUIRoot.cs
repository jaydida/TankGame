using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 通过一个父对象  实现所见即所得  这里是使用的特性[ExecuteAlways]
/// 而对子对象执行的顺序，也是通过父对象调用来实现的，而且将原本GUIControl基类中绘制的OnGui函数改成一个绘制函数，通过外部调用绘制。
/// </summary>
[ExecuteAlways]//编辑模式下也能执行
public class CustomGUIRoot : MonoBehaviour
{
    //用于存储  子对象  所以GUI控件的容器
    private CustomGUIControl[] allControls;


    // Start is called before the first frame update
    void Start()
    {
        //这里要是没有的话  在game模式下  并没有执行该语句，也就allControls没有获得赋值。
        allControls = GetComponentsInChildren<CustomGUIControl>();
    }

    //同一绘制子对象控件的内容
    private void OnGUI()
    {
        //通过每一次绘制之前  得到所有子对象控件的  父类脚本
        //这句代码 浪费性能 因为每次 gui都会来获取所有的  控件对应的脚本
        //编辑状态下  才会一直执行，而放在Start函数里也不行  所以这里要加上判断
        //Application.isPlaying游戏是否在运行
        //if (!Application.isPlaying)
        //{
        //    //获取所有子对象控件的父类脚本
        //    allControls = GetComponentsInChildren<CustomGUIControl>();
        //}
        //上面的在game状态下，面板取消不了，这里先不使用该方面//TODO
        allControls = GetComponentsInChildren<CustomGUIControl>();
        //遍历每一个控件  让其  执行绘制
        for (int i = 0; i< allControls.Length; i++)
        {
            allControls[i].DrawGUI();
        }
    }
}
