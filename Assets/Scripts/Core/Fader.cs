using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup = null;
    [SerializeField] float fadeTime = 2f;

	private void Awake()
	{
        int faderAmount = FindObjectsOfType<Fader>().Length;
        if (faderAmount > 1)
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
        SceneManager.sceneLoaded += FadeOutAction;
    }

	private void OnDisable()
	{
        SceneManager.sceneLoaded -= FadeOutAction;
    }

    private void FadeOutAction(Scene sc, LoadSceneMode mode)
	{
        Time.timeScale = 1f;
        canvasGroup.alpha = 1;
        StartCoroutine(FadeOut());
	}

    public void FadeInAction()
	{
        StartCoroutine(FadeIn());
	}

    
    
    //from white to black
    IEnumerator FadeIn()
	{
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / fadeTime;

            yield return null;
        }
    }

    //from black to white
    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeTime;

            yield return null;
        }
    }


}
