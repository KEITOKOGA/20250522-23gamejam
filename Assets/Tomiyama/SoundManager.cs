using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 音を鳴らす用のクラス。
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private List<SESet> _seList;
    [SerializeField] private List<BGMSet> _bgmList;
    [SerializeField] private AudioSource _seAus;
    [SerializeField] private AudioSource _bgmAus;

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

    public void PlaySE(SE se)
    {
        var clip = _seList.Find(x => x.se == se).clip;
        _seAus.PlayOneShot(clip);
    }
    public void PlaySE(AudioClip clip)
    {
        _seAus.PlayOneShot(clip);
    }
    
    public void PlayBGM(BGM bgm)
    {
        var clip = _bgmList.Find(x => x.bgm == bgm).clip;
        _bgmAus.clip = clip;
        _bgmAus.Play();
    }
}

[Serializable]
public struct SESet
{
    public SE se;
    public AudioClip clip;
}

[Serializable]
public struct BGMSet
{
    public BGM bgm;
    public AudioClip clip;
}

[Serializable]
public enum SE
{
    BeamShoot,
    BeamCharge,
    BeamHit,
    UISelect,
    UIMove,
    ResultWin,
    ResultLose,
}

[Serializable]
public enum BGM
{
    InGameBGM,
    OutGameBGM,
}