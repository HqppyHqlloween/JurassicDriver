using UnityEngine.Audio;
using System;
using UnityEngine;



    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public Sound[] sounds;

        void Awake()
        {

            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            instance = this;
            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        private void Start()
        {
            
        }

        public void Play (string name)
        {

            if(KevinGameManager.instance.mute.hasGodmode == true)
            {
            return;

            }
            else
            {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!!!");
                return;
            }
            s.source.Play();
            }


            
        }
    }
