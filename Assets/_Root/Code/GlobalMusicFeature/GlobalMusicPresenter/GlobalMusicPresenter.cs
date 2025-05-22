using UnityEngine;

namespace _Root.Code.GlobalMusicFeature.GlobalMusicPresenter
{
    public class GlobalMusicPresenter
    {
        public AudioSource AudioSource;

        public GlobalMusicPresenter(AudioSource audioSource)
        {
            AudioSource = audioSource;
        }

        public void StartMusic(AudioClip audioClip, bool loop)
        {
            AudioSource.Stop();
            AudioSource.clip = audioClip;
            AudioSource.loop = loop;
            AudioSource.Play();
        }

        public void StopMusic()
        {
            AudioSource.Stop();
        }
    }
}