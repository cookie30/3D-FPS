using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToSam : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // 如果滑鼠左鍵被按下去
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SampleScene"); // 讀取SampleScene場景
        }
    }
}
