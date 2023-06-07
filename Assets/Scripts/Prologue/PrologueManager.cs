using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueManager : MonoBehaviour
{
    [SerializeField] string nextSceneName;
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
            FadeManager.Instance.LoadScene(nextSceneName, 1f);
            SoundManager.Instance.PlaySE(SE.BtnEnter);
        }
    }
}
