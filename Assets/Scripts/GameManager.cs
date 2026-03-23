using UnityEngine;
using UnityEngine.InputSystem;

public enum Tag { Entertainment, Education, Tecnology }
public enum Type { Image, Video, Text }

public class GameManager : MonoBehaviour
{
    public int vigil;
    public int rep;
    public Tag content;
    public Type type;

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

        GetTrend();
    }

    void Update()
    {

    }

    void GetTrend()
    {
        content = (Tag)Random.Range(0, System.Enum.GetValues(typeof(Tag)).Length);
        type = (Type)Random.Range(0, System.Enum.GetValues(typeof(Type)).Length);


        Debug.Log($"Training: {type} of content {content}");
    }
}
