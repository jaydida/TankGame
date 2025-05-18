using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.WSA;

/// <summary>
/// PlayerPrefs数据管理器 统一管理数据的存储和读取
/// </summary>
public class PlayerPrefsDataMgr 
{
    private static PlayerPrefsDataMgr instance;

    public static PlayerPrefsDataMgr Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new PlayerPrefsDataMgr();
            }
            return instance;
        }
    }

    private PlayerPrefsDataMgr()
    {
        
    }

    /// <summary>
    /// 存储数据
    /// </summary>
    /// <param name="data">数据对象</param>
    /// <param name="keyName">数据对象的唯一key</param>
    public void SaveDate( object data, string keyName )
    {
        //就是通过  Type  得到传入数据对象的所有的  字段
        //MemberInfo[] memberInfos = type.GetMembers();
        //然后通过 PlayerPrefs来进行存储
        
        #region 获取传入数据对象的所有字段
        Type dataType = data.GetType();
        FieldInfo[] fieldInfos = dataType.GetFields();

        #endregion

        #region 定义一个key的规则  进行数据存储
        //keyName_数据类型_字段类型_字段名
        #endregion

        #region 遍历这些字段 进行数据存储
        string saveKeyName = "";
        FieldInfo info;
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            //得到具体的字段信息
            info = fieldInfos[i];
            //通过FiledInfo 可以直接获取到  字段类型  和字段名称
            //字段类型 info.FieldType.Name
            //字段名称 info.Name
            //根据我们定的key的拼接规则  来进行key的生成
            saveKeyName = keyName + "_" + dataType.Name + "_" + info.FieldType.Name + "_" + info.Name;

            //通过PlayerPrefs来进行存储

            //获取值
            //info.GetValue(data);
            //通过封装一个方法来进行存储，估计是方便不同类型的存储
            SaveValue(info.GetValue(data), saveKeyName);
        }
        PlayerPrefs.Save();
        #endregion
    }

    private void SaveValue(object value, string keyName)
    {
        //直接通过PlayerPrefs来进行存储
        //根据数据类型的不同 来决定使用哪一个API来进行存储
        Type fieldType = value.GetType();

        //类型判断
        if (fieldType == typeof(int))
        {
            PlayerPrefs.SetInt(keyName, (int)value);
        }
        else if (fieldType == typeof(float))
        {
            PlayerPrefs.SetFloat(keyName, (float)value);
        }
        else if (fieldType == typeof(string))
        {
            PlayerPrefs.SetString(keyName, (string)value);
        }
        else if (fieldType == typeof(bool))
        {
            //bool类型存储 需要转换成int来进行存储
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }
        //如何判断  泛型类的类型呢
        //通过反射  判断  父子关系
        //这相当于是判断  字段是不是IList的子类，List继承IList,泛型呢？
        else if(typeof(IList).IsAssignableFrom(fieldType))
        {
            //父类装子类
            IList list = value as IList;
            //先存储数量
            PlayerPrefs.SetInt(keyName,list.Count);
            int index = 0;
            foreach (object obj in list)
            {
                SaveValue(obj, keyName + index);
                ++index;
            }
            //for (int i = 0; i < list.Count; i++)
            //{
            //    SaveValue(list[i], keyName + index);
            //    ++index;
            //}
        }
        //判断是不是Dictionary类型  通过Dictonary的父类来判断
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            //父类装子类
            IDictionary dic = value as IDictionary;
            //先存储数量,只有存了长度才能根据其来确定读取次数
            PlayerPrefs.SetInt(keyName,dic.Count);
            //用于区分 标识的 区分 key
            int index = 0;
            foreach (object key in dic.Keys)
            {
                //存key
                SaveValue(key, keyName+ "_Key_" + index);
                //存value
                SaveValue(dic[key], keyName + "_Value_" + index);
                ++index;
            }

        }
        //自定义数据类型
        else
        {
            //Debug.LogError("不支持的类型");
            SaveDate(value, keyName);
        }
    }

    /// <summary>
    /// 读取数据
    /// </summary>
    /// <param name="type">想要读取数据的 数据类型Type</param>
    /// <param name="key">数据对象的唯一key 自己控制</param>
    /// <returns></returns>
    public object LoadDate(Type type, string key)
    {
        //不用object对象传入  而使用 Type类型传入
        //主要目的是节约一行代码 （在外部）
        //假如现在你要  读取一个player类型的数据  如果是object 你就必须在外部 new一个对象传入
        //现在有Type的  你只用传入  一个Type typeof（Player）就可以了  然后我在内部动态穿件一个对象给你返回出来
        //达到了 让你在外部 少写一行代码中的作用


        //根据你传入的类型  和  keyName
        //依据你存储数据时  key的拼接规则   来进行数据的获取赋值  返回出去


        //根据传入的类型  创建一个对象
        object data = Activator.CreateInstance(type);
        //获取传入数据对象的所有字段
        //即：要往这个new出来的对象中存储数据  填充数据
        FieldInfo[] infos = type.GetFields();
        //用于拼接key的字符串
        string loadKeyName = "";
        //用于存储  单个字段信息的  对象
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            //得到具体的字段信息
            info = infos[i];
            //key的拼接规则 一定是和存储时一致的  这样才能读取到对应数据
            loadKeyName = key + "_" + type.Name + "_" + info.FieldType.Name + "_" + info.Name;
            
            //有key  就可以结合  PlayerPrefs来读取数据
            //填充数据到data中
            info.SetValue(data, LoadValue(info.FieldType, loadKeyName));
        }

        return data;
    }

    /// <summary>
    /// 得到单个数据的方法
    /// </summary>
    /// <param name="fieldType">字段类型  用于判断 用哪个API读取</param>
    /// <param name="keyName">用于获取具体数据</param>
    /// <returns></returns>
    private object LoadValue(Type fieldType, string keyName)
    {
        //根据数据类型的不同 来决定使用哪一个API来进行读取
        if (fieldType == typeof(int))
        {
            return PlayerPrefs.GetInt(keyName);
        }
        else if (fieldType == typeof(float))
        {
            return PlayerPrefs.GetFloat(keyName);
        }
        else if (fieldType == typeof(string))
        {
            return PlayerPrefs.GetString(keyName);
        }
        else if (fieldType == typeof(bool))
        {
            //bool类型存储 需要转换成int来进行存储
            return PlayerPrefs.GetInt(keyName) == 1 ? true : false;
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            //得到长度
            int count = PlayerPrefs.GetInt(keyName);
            //实例化一个List对象  来进行赋值
            IList list = Activator.CreateInstance(fieldType) as IList;
            //根据长度来进行循环读取
            for (int i = 0; i < count; i++)
            {
                //读取数据
                //目的是要得到  List中泛型的类型fieldType.GetGenericArguments()[0]
                list.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            //得到长度
            int count = PlayerPrefs.GetInt(keyName);
            //实例化一个Dic对象  来进行赋值
            IDictionary dic = Activator.CreateInstance(fieldType) as IDictionary;

            Type[] KvType = fieldType.GetGenericArguments();
            for (int i = 0; i < count; i++)
            {
                ////读取键
                //object key = LoadValue(KvType[0], keyName + "_Key_" + i);
                ////读取值
                //object value = LoadValue(KvType[1], keyName + "_Value_" + i);
                ////添加到字典中
                //dic.Add(key, value);

                //直接总和
                dic.Add(LoadValue(KvType[0], keyName + "_Key_" + i), LoadValue(KvType[1], keyName + "_Value_" + i));
            }
            return dic;
        }
        else 
        {
            return LoadDate(fieldType, keyName);
        }
    }
}
