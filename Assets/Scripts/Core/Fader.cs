using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup = null;
    [SerializeField] float fadeTime = 2f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

	private void OnEnable()
	{
        SceneManager.sceneLoaded += ShowNextScene;
    }

	private void OnDisable()
	{
        SceneManager.sceneLoaded -= ShowNextScene;
    }

    //fade out to black
	public void FadeOutToNextScene()
	{
        StartCoroutine(FadeIn());
	}

    //when scene loads, fade out
    private void ShowNextScene(Scene scene,LoadSceneMode mode)
	{
        StartCoroutine(FadeOut());
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
            canvasGroup.alpha -= Time.deltaTime / 4;

            yield return null;
        }
    }


}
