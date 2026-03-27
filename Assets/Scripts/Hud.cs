using UnityEngine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class HudControler : MonoBehaviour
{
    public CanvasGroup cg;
    public Button startar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startar.onClick.AddListener(() =>
        {
            StartCoroutine(FadeOut());
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


