using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public GameObject exitPanel;
    void Start()
    {
        exitPanel.SetActive(false);
    }

    public void buton(int deger)
    {
        if (deger == 1)
        {
            exitPanel.SetActive(true);
        }
        else if (deger == 0)
        {
            exitPanel.SetActive(false);
        }
        else if (deger == -1)
        {
            Application.Quit();
        }
    }
}
