using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    bool isStart;

    void Update()
    {
        if (isStart)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isStart = true;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
