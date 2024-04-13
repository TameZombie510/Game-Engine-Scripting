using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    AudioSource m_AudioSource;
  
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    
    public void Init(AudioClip clip, bool loop)
    {
        m_AudioSource.clip = clip;
        m_AudioSource.loop = loop;
    }

    public void Play()
    {
        m_AudioSource.Play();
    }

    public void Stop()
    {  
      m_AudioSource.Stop();
        
    }

}
