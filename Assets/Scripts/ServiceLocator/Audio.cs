namespace ServiceLocator
{
    public abstract class Audio
    {
        public abstract void PlaySound(int soundID);
        public abstract void StopSound(int soundID);
        public abstract void StopAllSounds();
    }
}
