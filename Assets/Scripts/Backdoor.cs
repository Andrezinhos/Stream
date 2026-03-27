using System.Collections;
using UnityEngine;

public class Backdoor : MonoBehaviour
{
    public int timeMax = 20;
    public static bool isActive;
    Coroutine backdoor;

    public void Initialized()
    {
        if (backdoor != null) return;
        backdoor = StartCoroutine(EventBackdoor());
    }

    private void OnEnable()
    {
        GameManager.OnBackdoor += CanRun;
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
    }

    public IEnumerator EventBackdoor()
    {
        Debug.Log("BackDoor On");
        yield return new WaitForSeconds(timeMax);
        Debug.Log("BackDoor Off");
        isActive = false;
    }
}
