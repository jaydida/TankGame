using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float time = 1.5f; //����ʱ��
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
