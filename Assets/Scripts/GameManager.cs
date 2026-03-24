using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public enum Tag { Entertainment, Education, Tecnology }
public enum Type { Image, Video, Text }

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI tagText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI selecText;
    public int vigil;
    public int rep;
    public Tag content;
    public Type type;
    public List<Content> contents = new List<Content>();
    public InputAction interact;

    bool isAccept; 
    int totalSelected = 0;
    int correctSelec = 0;
    int wrongSelec = 0;
    List<Content> selected = new List<Content>();

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        vigil = 0;
        rep = 0;
        interact = InputSystem.actions.FindAction("Interact");


        // ENTRETENIMENTO
        contents.Add(new Content
        {
            title = "Meme de Gatos",
            tag = Tag.Entertainment,
            type = Type.Image,
        });
        contents.Add(new Content
        {
            title = "Cartaz de Filme",
            tag = Tag.Entertainment,
            type = Type.Image,
        });
        contents.Add(new Content
        {
            title = "Foto de Férias",
            tag = Tag.Entertainment,
            type = Type.Image,
        });
        contents.Add(new Content
        {
            title = "Post de Lifestyle",
            tag = Tag.Entertainment,
            type = Type.Text,
        });
        contents.Add(new Content
        {
            title = "Trecho de Filme",
            tag = Tag.Entertainment,
            type = Type.Video,
        });
        contents.Add(new Content
        {
            title = "Video Curto",
            tag = Tag.Entertainment,
            type = Type.Video,
        });
        contents.Add(new Content
        {
            title = "Video clipe Musical",
            tag = Tag.Entertainment,
            type = Type.Video,
        });

        //EDUCATION
        contents.Add(new Content
        {
            title = "Mapa Mental",
            tag = Tag.Education,
            type = Type.Image
        });
        contents.Add(new Content
        {
            title = "Mapa Mental",
            tag = Tag.Education,
            type = Type.Image
        });
        contents.Add(new Content
        {
            title = "Aula Matemática",
            tag = Tag.Education,
            type = Type.Video,
        });
        contents.Add(new Content
        {
            title = "Curiosidade Histórica",
            tag = Tag.Education,
            type = Type.Video,
        });
        contents.Add(new Content
        {
            title = "Pesquisa Universitária",
            tag = Tag.Education,
            type = Type.Text,
        });

        //TECNOLOGIA
        contents.Add(new Content
        {
            title = "Curso de Programação",
            tag = Tag.Tecnology,
            type = Type.Video,
        });
        contents.Add(new Content
        {
            title = "Evolução dos Gráficos",
            tag = Tag.Tecnology,
            type = Type.Video,
        });
        contents.Add(new Content
        {
            title = "Código Aberto",
            tag = Tag.Tecnology,
            type = Type.Text,
        });
        contents.Add(new Content
        {
            title = "Código Aberto",
            tag = Tag.Tecnology,
            type = Type.Text,
        });

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

    public void CheckContent()
    {
        foreach(Content c in selected)
        {
            if (c.tag == content && c.type == type) correctSelec++;
            else wrongSelec++;
            Debug.Log(correctSelec);
        }
    }

    public void ButtonAccept()
    {
        selected.Add(currOption);
        foreach (var c in selected) Debug.Log($"{c.title} - {c.tag} - {c.type}");
        totalSelected += 1;
        selecText.text = totalSelected.ToString();  
        RandomContent(3);
    }

    void Update()
    {
        
    }

    void GetTrend()
    {
        content = (Tag)Random.Range(0, System.Enum.GetValues(typeof(Tag)).Length);
        type = (Type)Random.Range(0, System.Enum.GetValues(typeof(Type)).Length);

        //Debug.Log($"Training: {type} of content {content}");
    }
}
