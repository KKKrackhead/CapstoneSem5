using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup FadeInFadeOut;

    public void StartGame()
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 1f, 2.2f).setOnComplete(lanjut);
    }

    private void lanjut()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        LeanTween.alphaCanvas(FadeInFadeOut, 1f, 2.2f).setOnComplete(keluar);
    }

    private void keluar()
    {
        Application.Quit();
    }
}
