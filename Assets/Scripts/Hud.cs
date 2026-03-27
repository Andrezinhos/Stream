using UnityEngine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Hud: MonoBehaviour
{
    public CanvasGroup cg;
    public Button startar;

    public static Hud instance;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        startar.onClick.AddListener(() =>
        {
            StartCoroutine(FadeOut());
            SceneManager.LoadScene("Jogo");
        });


    }
    public IEnumerator FadeOut(Action callback = null)
    {
        cg.alpha = 1;
        cg.blocksRaycasts = false;
        cg.interactable = false;
        while (cg.alpha > 0)
        {
            cg.alpha -= Time.deltaTime;
            yield return null;
        }
        cg.alpha = 0;
        callback?.Invoke();
    }
}


