using UnityEngine;

namespace TowerDefence.Options
{
	public class PlayerPreferences : MonoBehaviour
	{
		const string MUSIC_VOLUME_KEY = "music volume";
		const string MASTER_VOLUME_KEY = "music volume";

		//MUSIC
		public static void SetMusicVolume(float volume)
		{
			PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
		}

		public static float GetMusicVolume()
		{
			return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
		}

		//MASTER
		public static void SetMasterVolume(float volume)
		{
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}

		public static float GetMasterVolume()
		{
			return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
		}
	}
}


