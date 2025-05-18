using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Í¨¹ýÂß¼­
            //SceneManager.LoadScene("BeginScene");
            Time.timeScale = 0f;
            WinPanel.Instance.ShowPanel();
        }
    }
}
