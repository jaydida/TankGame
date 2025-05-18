using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.WSA;

/// <summary>
/// PlayerPrefs���ݹ����� ͳһ�������ݵĴ洢�Ͷ�ȡ
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
    /// �洢����
    /// </summary>
    /// <param name="data">���ݶ���</param>
    /// <param name="keyName">���ݶ����Ψһkey</param>
    public void SaveDate( object data, string keyName )
    {
        //����ͨ��  Type  �õ��������ݶ�������е�  �ֶ�
        //MemberInfo[] memberInfos = type.GetMembers();
        //Ȼ��ͨ�� PlayerPrefs�����д洢
        
        #region ��ȡ�������ݶ���������ֶ�
        Type dataType = data.GetType();
        FieldInfo[] fieldInfos = dataType.GetFields();

        #endregion

        #region ����һ��key�Ĺ���  �������ݴ洢
        //keyName_��������_�ֶ�����_�ֶ���
        #endregion

        #region ������Щ�ֶ� �������ݴ洢
        string saveKeyName = "";
        FieldInfo info;
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            //�õ�������ֶ���Ϣ
            info = fieldInfos[i];
            //ͨ��FiledInfo ����ֱ�ӻ�ȡ��  �ֶ�����  ���ֶ�����
            //�ֶ����� info.FieldType.Name
            //�ֶ����� info.Name
            //�������Ƕ���key��ƴ�ӹ���  ������key������
            saveKeyName = keyName + "_" + dataType.Name + "_" + info.FieldType.Name + "_" + info.Name;

            //ͨ��PlayerPrefs�����д洢

            //��ȡֵ
            //info.GetValue(data);
            //ͨ����װһ�����������д洢�������Ƿ��㲻ͬ���͵Ĵ洢
            SaveValue(info.GetValue(data), saveKeyName);
        }
        PlayerPrefs.Save();
        #endregion
    }

    private void SaveValue(object value, string keyName)
    {
        //ֱ��ͨ��PlayerPrefs�����д洢
        //�����������͵Ĳ�ͬ ������ʹ����һ��API�����д洢
        Type fieldType = value.GetType();

        //�����ж�
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
            //bool���ʹ洢 ��Ҫת����int�����д洢
            PlayerPrefs.SetInt(keyName, (bool)value ? 1 : 0);
        }
        //����ж�  �������������
        //ͨ������  �ж�  ���ӹ�ϵ
        //���൱�����ж�  �ֶ��ǲ���IList�����࣬List�̳�IList,�����أ�
        else if(typeof(IList).IsAssignableFrom(fieldType))
        {
            //����װ����
            IList list = value as IList;
            //�ȴ洢����
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
        //�ж��ǲ���Dictionary����  ͨ��Dictonary�ĸ������ж�
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            //����װ����
            IDictionary dic = value as IDictionary;
            //�ȴ洢����,ֻ�д��˳��Ȳ��ܸ�������ȷ����ȡ����
            PlayerPrefs.SetInt(keyName,dic.Count);
            //�������� ��ʶ�� ���� key
            int index = 0;
            foreach (object key in dic.Keys)
            {
                //��key
                SaveValue(key, keyName+ "_Key_" + index);
                //��value
                SaveValue(dic[key], keyName + "_Value_" + index);
                ++index;
            }

        }
        //�Զ�����������
        else
        {
            //Debug.LogError("��֧�ֵ�����");
            SaveDate(value, keyName);
        }
    }

    /// <summary>
    /// ��ȡ����
    /// </summary>
    /// <param name="type">��Ҫ��ȡ���ݵ� ��������Type</param>
    /// <param name="key">���ݶ����Ψһkey �Լ�����</param>
    /// <returns></returns>
    public object LoadDate(Type type, string key)
    {
        //����object������  ��ʹ�� Type���ʹ���
        //��ҪĿ���ǽ�Լһ�д��� �����ⲿ��
        //����������Ҫ  ��ȡһ��player���͵�����  �����object ��ͱ������ⲿ newһ��������
        //������Type��  ��ֻ�ô���  һ��Type typeof��Player���Ϳ�����  Ȼ�������ڲ���̬����һ��������㷵�س���
        //�ﵽ�� �������ⲿ ��дһ�д����е�����


        //�����㴫�������  ��  keyName
        //������洢����ʱ  key��ƴ�ӹ���   ���������ݵĻ�ȡ��ֵ  ���س�ȥ


        //���ݴ��������  ����һ������
        object data = Activator.CreateInstance(type);
        //��ȡ�������ݶ���������ֶ�
        //����Ҫ�����new�����Ķ����д洢����  �������
        FieldInfo[] infos = type.GetFields();
        //����ƴ��key���ַ���
        string loadKeyName = "";
        //���ڴ洢  �����ֶ���Ϣ��  ����
        FieldInfo info;
        for (int i = 0; i < infos.Length; i++)
        {
            //�õ�������ֶ���Ϣ
            info = infos[i];
            //key��ƴ�ӹ��� һ���Ǻʹ洢ʱһ�µ�  �������ܶ�ȡ����Ӧ����
            loadKeyName = key + "_" + type.Name + "_" + info.FieldType.Name + "_" + info.Name;
            
            //��key  �Ϳ��Խ��  PlayerPrefs����ȡ����
            //������ݵ�data��
            info.SetValue(data, LoadValue(info.FieldType, loadKeyName));
        }

        return data;
    }

    /// <summary>
    /// �õ��������ݵķ���
    /// </summary>
    /// <param name="fieldType">�ֶ�����  �����ж� ���ĸ�API��ȡ</param>
    /// <param name="keyName">���ڻ�ȡ��������</param>
    /// <returns></returns>
    private object LoadValue(Type fieldType, string keyName)
    {
        //�����������͵Ĳ�ͬ ������ʹ����һ��API�����ж�ȡ
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
            //bool���ʹ洢 ��Ҫת����int�����д洢
            return PlayerPrefs.GetInt(keyName) == 1 ? true : false;
        }
        else if (typeof(IList).IsAssignableFrom(fieldType))
        {
            //�õ�����
            int count = PlayerPrefs.GetInt(keyName);
            //ʵ����һ��List����  �����и�ֵ
            IList list = Activator.CreateInstance(fieldType) as IList;
            //���ݳ���������ѭ����ȡ
            for (int i = 0; i < count; i++)
            {
                //��ȡ����
                //Ŀ����Ҫ�õ�  List�з��͵�����fieldType.GetGenericArguments()[0]
                list.Add(LoadValue(fieldType.GetGenericArguments()[0], keyName + i));
            }
            return list;
        }
        else if (typeof(IDictionary).IsAssignableFrom(fieldType))
        {
            //�õ�����
            int count = PlayerPrefs.GetInt(keyName);
            //ʵ����һ��Dic����  �����и�ֵ
            IDictionary dic = Activator.CreateInstance(fieldType) as IDictionary;

            Type[] KvType = fieldType.GetGenericArguments();
            for (int i = 0; i < count; i++)
            {
                ////��ȡ��
                //object key = LoadValue(KvType[0], keyName + "_Key_" + i);
                ////��ȡֵ
                //object value = LoadValue(KvType[1], keyName + "_Value_" + i);
                ////��ӵ��ֵ���
                //dic.Add(key, value);

                //ֱ���ܺ�
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
