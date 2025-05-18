using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBeginPanel : MonoBehaviour
{
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnEnd;
    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        btnBegin.clickEvent += () => 
        {
            Debug.Log("�����ʼ��ť");
        };
        btnEnd.clickEvent += () =>
        {
            Debug.Log("������ť���");
        };
        btnClose.clickEvent += () =>
        {
            this.gameObject.SetActive(false);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
