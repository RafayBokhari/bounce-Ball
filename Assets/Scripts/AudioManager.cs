using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audiosource1;
    public AudioSource audiosource2;
    public static AudioManager Instance;
   
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
           // Destroy(gameObject);
        }
    }

  public void Play()
    {
       
        audioSource.Play(); 

    }
        
    public void gem()
    {
        audiosource1.Play();
    }


    public void ballaudio()
    {
        audiosource2.Play();
    }
}
