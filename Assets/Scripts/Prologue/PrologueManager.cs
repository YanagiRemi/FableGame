using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrologueManager : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    bool isStart;
    bool canInput;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        canInput = true;
    }

    void Update()
    {
        if (!canInput)
        {
            return;
        }
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
