using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public static Tooltip Instance;
    public TextMeshProUGUI text;

    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void show(string txt)
    {
        gameObject.SetActive(true);
        text.text = txt; 
    }

    public void hide() 
    {
        gameObject.SetActive(false);
    }
}
