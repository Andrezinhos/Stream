using System.Collections;
using UnityEngine;

public class Backdoor : MonoBehaviour
{
    public int timeMax = 20;
    public bool isActive;
    bool hasPlayer;
    Coroutine backdoor;

    public static event System.Action OnActiveBackdoor;


    public void Initialized()
    {
        if (backdoor != null) return;
        //backdoor = StartCoroutine()
    }

    private void Update()
    {
        if (!isActive)
        {
            
        }
    }

    public IEnumerator EventBackdoor()
    {
        isActive = true;
        while (isActive)
        {
            yield return new WaitForSeconds(timeMax);
            isActive = false;
        }
    }
}
