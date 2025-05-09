using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    [SerializeField] private GameObject OptionWindow = null;

    void Start()
    {
        if (OptionWindow != null)
        {
            OptionWindow.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveOptionWindow()
    {
        if (!OptionWindow.active)
        {
            OptionWindow.SetActive (true);
        }
        else
        {
            OptionWindow.SetActive (false);
        }
    }
}
