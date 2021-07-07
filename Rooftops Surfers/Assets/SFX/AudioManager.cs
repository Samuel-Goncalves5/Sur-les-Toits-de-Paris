using Array = System.Array;
using NullReferenceException = System.NullReferenceException;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;
    public static AudioManager instance;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else {Destroy(gameObject); return;}
        
        DontDestroyOnLoad(gameObject);
        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }
    
    private void Start() => UpdateVolume(1);

    public void UpdateVolume(float Volume)
    {
        foreach (Sound sound in Sounds) {sound.Source.volume = sound.Volume * Volume;}
    }

    public void Play(string name, bool play = true)
    {
        Sound s = Array.Find(Sounds, sound => sound.Name == name);
        if (s == null)
            throw new NullReferenceException("Play : " + name + " not found");

        if (play) s.Source.Play();
        else s.Source.Stop();
    }
    
    public void Play(Sound sound, bool play = true) => Play(sound.Name, play);
}