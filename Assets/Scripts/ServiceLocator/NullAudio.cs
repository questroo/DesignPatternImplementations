using UnityEngine;
namespace ServiceLocator
{
    public class NullAudio : Audio
    {
        public override void PlaySound(int soundID)
        {
            Debug.Log("Do nothing");
        }

        public override void StopAllSounds()
        {
            Debug.Log("Do nothing");
        }

        public override void StopSound(int soundID)
        {
            Debug.Log("Do nothing");
        }
    }
}
