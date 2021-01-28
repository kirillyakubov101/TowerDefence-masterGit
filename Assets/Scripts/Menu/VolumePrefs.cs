using System;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.Options
{
    public class VolumePrefs : MonoBehaviour
    {
        [SerializeField] Slider musicSlider = null;
        [SerializeField] Slider masterSlider = null;

        public static event Action<float> onMusicVolumeChange;
        public static event Action<float> onMasterVolumeChange;


        // Start is called before the first frame update
        void Start()
        {
            musicSlider.value = PlayerPreferences.GetMusicVolume();
            masterSlider.value = PlayerPreferences.GetMasterVolume();
        }

        public float GetSliderValue()
		{
            return musicSlider.value;
        }

        public void MusicVolumeChange()
		{
            onMusicVolumeChange?.Invoke(musicSlider.value);

        }

        public void MasterVolumeChange()
        {
            onMasterVolumeChange?.Invoke(masterSlider.value);
        }
    }
}


