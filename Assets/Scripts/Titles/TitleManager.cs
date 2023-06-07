using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    bool isStart;

    private void Start()
    {
        SoundManager.Instance.PlayBGM(BGM.Title);
    }

    void Update()
    {
        if (isStart)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            isStart = true;
            FadeManager.Instance.LoadScene("Prologue", 1f);
            SoundManager.Instance.PlaySE(SE.BtnEnter);
        }
    }
}
