using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panel;

    public GameObject inputUI;

    private void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    private void Update()
    {

    }
}
