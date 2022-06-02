using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SFXType
{
   BallBounce,
   Explode,
   Catapult,
   Barrel
   
}


public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private List<SFXData> _sfxDatas = new List<SFXData>();
    [SerializeField] private AudioMixer _audioMixer;
    private static AudioManager _instance;

    private void Awake()
    {
        
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void PlaySFXInner(SFXType sfx)
    {
        var sfxData = _sfxDatas.Find(data => data.SFX == sfx);
        if (sfxData != null)
        {
            _sfxSource.PlayOneShot(sfxData.Audio);
        }
    }

    private void StopSFXInner()
    {
            _sfxSource.Stop();
    }

    private void StopAllSounds()
    {
        _sfxSource.Stop();
    }

    public static void StopSFX()
    {
        _instance.StopSFXInner();
    }

    public static void PlaySFX(SFXType sfx)
    {
        _instance.PlaySFXInner(sfx);
    }

}

[System.Serializable]
public class SFXData
{
    [SerializeField] private SFXType _sfx;
    [SerializeField] private AudioClip _audioClip;

    public SFXType SFX => _sfx;
    public AudioClip Audio => _audioClip;
      
}


[System.Serializable]
public class MusicData
{
    [SerializeField] private AudioClip _clip;
    public AudioClip Music => _clip;

}