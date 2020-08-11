using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawner : MonoBehaviour
{
    private static TextSpawner instance;
    public static TextSpawner Instance => instance;

    public Canvas Canvas;
    public GameObject FadingTextPrefab;
    public GameObject FadingTextLongerPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // @really?
    public void SpawnText( string msg, float fontSize, Color color, Vector3 at, Vector3 offset )
    {
        var fadingText = Instantiate(FadingTextPrefab, Vector2.zero, FadingTextPrefab.transform.rotation).GetComponent<FadingText>();

        var screenPos = Camera.main.WorldToScreenPoint(at);

        fadingText.gameObject.transform.SetParent(Canvas.transform, false);
        fadingText.gameObject.transform.position = screenPos + offset;

        fadingText.Modify(msg, fontSize, color);
    }

    public void SpawnFadingTextLonger( string msg, float fontSize, Color color, Vector3 at, Vector3 offset )
    {
        var fadingText = Instantiate(FadingTextLongerPrefab, Vector2.zero, FadingTextLongerPrefab.transform.rotation).GetComponent<FadingText>();

        var screenPos = Camera.main.WorldToScreenPoint(at);

        fadingText.gameObject.transform.SetParent(Canvas.transform, false);
        fadingText.gameObject.transform.position = screenPos + offset;

        fadingText.Modify(msg, fontSize, color);
    }
}