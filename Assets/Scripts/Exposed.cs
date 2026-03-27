using System.Collections;
using UnityEngine;

public class Exposed : MonoBehaviour
{
    public int timeMax = 20;
    public static bool isActive;
    bool hasPlayer;
    Coroutine exposed;

    public void Initialized()
    {
        if (exposed != null) return;
        exposed = StartCoroutine(EventBackdoor());
    }

    private void OnEnable()
    {
        GameManager.OnExposed += CanRun;
    }

    void CanRun()
    {
        isActive = true;
    }

    private void Update()
    {
        if (isActive)
        {
            Initialized();
        }
        else
        {
            StopCoroutine(exposed);
        }
    }

    public IEnumerator EventBackdoor()
    {
        Debug.Log("BackDoor On");
        yield return new WaitForSeconds(timeMax);
        Debug.Log("BackDoor Off");
        isActive = false;
    }
}
