namespace D2D.Audio
{
    public class CrossSceneAudio : AudioPlayer
    {
        private void Awake()
        {
            RemoveDuplicates();
        
            DontDestroyOnLoad(transform.gameObject);
        }

        private void RemoveDuplicates()
        {
            var audios = FindObjectsOfType<CrossSceneAudio>();
            if (audios.Length > 1)
            {
                Destroy(audios[0] == this ? audios[0].gameObject : audios[1].gameObject);
            }
        }
    }
}