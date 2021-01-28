using UnityEngine;

namespace TowerDefence.Options
{
	public class Options : MonoBehaviour
	{
		[SerializeField] AudioSource AudioSourceMainThemeSound = null;

		private void Awake()
		{
			int count = FindObjectsOfType<Options>().Length;
			if (count > 1)
			{
				Destroy(gameObject);
			}
			else
			{
				DontDestroyOnLoad(gameObject);
			}
		}

		private void OnEnable()
		{
			VolumePrefs.onMusicVolumeChange += HandleMusicVolume;
			VolumePrefs.onMasterVolumeChange += HandleMasterVolume;
		}

		private void OnDisable()
		{
			VolumePrefs.onMusicVolumeChange -= HandleMusicVolume;
			VolumePrefs.onMasterVolumeChange -= HandleMasterVolume;
		}

		// Start is called before the first frame update
		void Start()
		{
			PlayerPreferences.SetMusicVolume(0.7f);
			PlayerPreferences.SetMasterVolume(0.7f);
			AudioSourceMainThemeSound.volume = PlayerPreferences.GetMusicVolume();
		}

		private void HandleMusicVolume(float volume)
		{
			PlayerPreferences.SetMusicVolume(volume);
			AudioSourceMainThemeSound.volume = PlayerPreferences.GetMusicVolume();
		}

		private void HandleMasterVolume(float volume)
		{
			AudioListener.volume = volume;
		}
	}
}


