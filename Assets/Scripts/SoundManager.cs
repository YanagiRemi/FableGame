using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceBGM;
    [SerializeField] AudioSource audioSourceSE;


    [SerializeField] List<AudioDataBGM> audioBGMs = new List<AudioDataBGM>();
    [SerializeField] List<AudioDataSE> audioSEs = new List<AudioDataSE>();

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGM type)
    {
        AudioDataBGM audioDataBGM = audioBGMs.Find(data => data.type == type);
        audioSourceBGM.clip = audioDataBGM.audioClip;
        audioSourceBGM.Play();
    }

    public void PlaySE(SE type)
    {
        AudioDataSE audioDataSE = audioSEs.Find(data => data.type == type);
        audioSourceSE.PlayOneShot(audioDataSE.audioClip);
    }

}

public enum BGM
{
    Title,
    Prolo,
    Main,
    Ending,
}

public enum SE
{
    BtnEnter,
    GimmickClear,
    BtnItemGet,
    BtnItemSet,
}

[System.Serializable]
class AudioDataBGM
{
    public BGM type;
    public AudioClip audioClip;
}
[System.Serializable]
class AudioDataSE
{
    public SE type;
    public AudioClip audioClip;
}