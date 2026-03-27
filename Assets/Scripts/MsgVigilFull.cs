using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MsgVigilFull : MonoBehaviour
{
    public TextMeshProUGUI msg;

    private void Start()
    {
        FirstLine();
    }

    void FirstLine()
    {
        msg.text = "Eles dizem que você tentou ir contra a empresa…";
        Invoke("SecondLine", 3.0f);
    }
    void SecondLine()
    {
        msg.text = "e que poderia ter acabado com ela…";
        Invoke("ThirdLine", 3.0f);
    }
    void ThirdLine()
    {
        msg.text = "mas não vejo maldade em você…";
        Invoke("FourthLine", 3.0f);
    }
    void FourthLine()
    {
        msg.text = "o que os humanos realmente querem tanto?..";
        Invoke("FifthLine", 3.0f);
    }
    void FifthLine()
    {
        msg.text = "o que buscam com esse…";
        Invoke("SixthLine", 3.0f);
    }
    void SixthLine()
    {
        msg.text = "controle?";
        Invoke("GoToMenu", 3.0f);
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("MENU");
    }
}
