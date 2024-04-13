using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    //private AudioSource m_AudioSource;

    [SerializeField] private GameObject m_SoundEffectPrefab;

    [SerializeField] private AudioClip phaseOne;
    [SerializeField] private AudioClip phaseTwo;
    [SerializeField] private AudioClip jumpscare;

    private static Dictionary<SoundType, SoundEffect> SoundList = new Dictionary<SoundType, SoundEffect>();
    

    public enum SoundType
    {
        PhaseOne = 1,
        PhaseTwo = 2,
        Jumpscare = 3
    }

    private void Awake()
    {
        //m_AudioSource = GetComponent<AudioSource>();
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void PlaySound(SoundType sound)
    {
        instance.PrivPlaySound(sound);
    }

    public static void StopSound(SoundType sound)
    {
        SoundList[sound].Stop();
        SoundList.Remove(sound);
    }

    private void PrivPlaySound(SoundType sound)
    {
        AudioClip clip = null;
        bool loop = false;

        switch (sound)
        {
            case SoundType.PhaseOne: clip = phaseOne; loop = true; break;
            case SoundType.PhaseTwo: clip = phaseTwo; loop = true; break;
            case SoundType.Jumpscare: clip = jumpscare; loop = false; break;
        }

        //m_AudioSource.Play();

        GameObject newSound = Instantiate(m_SoundEffectPrefab);
        SoundEffect newSoundEffect = newSound.GetComponent<SoundEffect>();
        newSoundEffect.Init(clip, loop);
        newSoundEffect.Play();

        SoundList.Add(sound, newSoundEffect);
    }
}
