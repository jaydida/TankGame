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
            Debug.Log("点击开始按钮");
        };
        btnEnd.clickEvent += () =>
        {
            Debug.Log("结束按钮点击");
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
