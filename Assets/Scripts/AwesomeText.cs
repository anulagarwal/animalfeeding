using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AwesomeText : MonoBehaviour
{
    [SerializeField] public string text;
    [SerializeField] private float upSpeed;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private float destroyDelay;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
    public void SetText(string s)
    {
        GetComponentInChildren<TextMeshPro>().text = s;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, upSpeed, 0) * Time.deltaTime);
        GetComponentInChildren<TextMeshPro>().alpha -= fadeSpeed;
    }
}
