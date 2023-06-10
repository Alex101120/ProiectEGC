using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Muzica : MonoBehaviour
{
    public AudioClip[] songs;
    private int currentSongIndex = 0;
    private AudioSource audioSource;

    [SerializeField]
    private Slider volumeSlider;

    private static Muzica instance;
    private static Slider staticVolumeSlider;

    private static float savedVolume = 1.0f;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        staticVolumeSlider = volumeSlider;
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        // Find the volume slider in the initial scene
        volumeSlider = FindVolumeSlider();

        PlayCurrentSong();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnVolumeChanged(float volume)
    {
        audioSource.volume = volume;
        savedVolume = volume;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the volume slider in the new scene
        volumeSlider = FindVolumeSlider();

        if (audioSource.isPlaying)
            return;

        PlayCurrentSong();
    }

    void PlayCurrentSong()
    {
        if (currentSongIndex >= songs.Length)
        {
            currentSongIndex = 0;
        }

        audioSource.Stop();
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();

        currentSongIndex++;
    }

    Slider FindVolumeSlider()
    {
        Slider[] sliders = Resources.FindObjectsOfTypeAll<Slider>();

        foreach (Slider slider in sliders)
        {
            if (slider.name == "Volume Music")
            {
                return slider;
            }
        }

        return null;
    }

    public static Slider GetStaticVolumeSlider()
    {
        return staticVolumeSlider;
    }
}
