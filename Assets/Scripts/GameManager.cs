using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;

public enum Tag { Entertainment, Education, Tecnology }
public enum Type { Image, Video, Text }

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI tagText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI selecText;
    public TextMeshProUGUI trendText;
    public TextMeshProUGUI vigilText;
    public TextMeshProUGUI repText;
    public int vigil;
    public int rep;
    public Tag content;
    public Type type;
    public List<Content> contents = new List<Content>();
    public InputAction interact;
    public static event System.Action OnBackdoor;
    public static event System.Action OnExposed;

    bool isBackdoorActive; 
    bool isExposedActive; 
    bool canUseData; 
    bool canUseServer; 
    int totalSelected = 0;
    public int correctSelec = 0;
    public int wrongSelec = 0;
    List<Content> selected = new List<Content>();

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        vigil = 0;
        rep = 0;
        vigilText.text = vigil.ToString();
        repText.text = rep.ToString();
        isBackdoorActive = false;
        isExposedActive = false;
        canUseData = false;
        canUseServer = false;
        interact = InputSystem.actions.FindAction("Interact");

        contents = ContentsBase.GetContents();

        GetTrend();
        RandomContent(3);
    }

    public List<Content> GetRandomContent(int amount)
    {
        List<Content> result = new List<Content>();

        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, contents.Count);
            result.Add(contents[index]);
        }
        return result;
    }

    public Content currOption;
    public void RandomContent(int amount)
    {
        List<Content> options = GetRandomContent(3);

        foreach (var c in options)
        {
            currOption = c;
            text.text = c.title;
            tagText.text = c.tag.ToString();
            typeText.text = c.type.ToString();
        }
    }

    public void ButtonAccept()
    {
        if (totalSelected == 5)
        {
            canUseData = true;
            return;
        }
        selected.Add(currOption);
        totalSelected += 1;
        selecText.text = totalSelected.ToString();
        RandomContent(3);
    }

    public void ButtonReject()
    {
        if (totalSelected == 5)
        {
            canUseData = true;
            canUseServer = false;
            return;
        }
        RandomContent(3);
    }

    bool isCorrect;
    public void ValidateChoice()
    {
        foreach (Content c in selected)
        {
            if (c.tag == content && c.type == type)
            {
                isCorrect = true;
                if (isExposedActive) Vigil();
            }
            else
            {
                isCorrect = false;
                if (isBackdoorActive) Vigil();
            }

        }
        if (isCorrect) correctSelec++;
        else wrongSelec++;

        vigilText.text = vigil.ToString();
        repText.text = rep.ToString();

        canUseServer = true;
    }
    void Vigil()
    {
        if (!isBackdoorActive) return;
        else
        {
            vigil++;
            Debug.Log("Vigil: " + vigil);
        }
    }

    public void SendToServer()
    {
        if (!canUseServer) return;
        Invoke("GetTrend", 1.0f);
    }
    public void SendToData()
    {
        if (!canUseData) return;
        Invoke("ValidateChoice", 1.0f);
    }
    void GetTrend()
    {
        content = (Tag)Random.Range(0, System.Enum.GetValues(typeof(Tag)).Length);
        type = (Type)Random.Range(0, System.Enum.GetValues(typeof(Type)).Length);

        selected.Clear();
        totalSelected = 0;
        selecText.text = totalSelected.ToString();

        if (wrongSelec >= 3) OnBackdoor?.Invoke();
        else if (correctSelec >= 5) OnExposed?.Invoke();

        trendText.text = "Training: " + type + " | Content: " + content;
    }
}
