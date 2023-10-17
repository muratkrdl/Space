using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Ateş Etme")]
    [SerializeField] AudioClip ateşEtmeSesi;
    [SerializeField] [Range(0f,1f)] float ateşEtmeSesDüzeyi = 1f;

    [Header("Patlama")]
    [SerializeField] AudioClip patlamaSesi;
    [SerializeField] [Range(0f,1f)] float patlamaSesiDüzeyi = 1f;

    static AudioPlayer örnek;

    //public AudioPlayer GetÖrnek()
    //{
    //    return örnek;
    //}

    void Awake() 
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int auidoPlayerCount = FindObjectsOfType(GetType()).Length;
        //if(auidoPlayerCount > 1)
        if(örnek != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            örnek = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 anaKamera = (Camera.main.transform.position);
            AudioSource.PlayClipAtPoint  (clip,anaKamera, volume);
        }
    }

    public void PlayAteşEtmeSesi()
    {
        PlayClip(ateşEtmeSesi,ateşEtmeSesDüzeyi);
    }

    public void PlayPatlamaSesi()
    {
        PlayClip(patlamaSesi,patlamaSesiDüzeyi);
    }

    //public void PlayAteşEtmeSesi()
    //{
    //    if(ateşEtmeSesi != null)
    //    {
    //    AudioSource.PlayClipAtPoint(ateşEtmeSesi,Camera.main.transform.position,ateşEtmeSesDüzeyi);
    //    }
    //}
    //
    //public void PlayPatlamaSesi()
    //{
    //    if(patlamaSesi != null)
    //    {
    //    AudioSource.PlayClipAtPoint(patlamaSesi,Camera.main.transform.position,patlamaSesiDüzeyi);
    //    }
    //}
    //
}
