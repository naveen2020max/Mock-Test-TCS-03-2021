using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    public GameObject[] panels;

    private int currentindex = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePanel();
        MobileInput.instance.ON_Tap += Tap;
    }

    // Update is called once per frame
   
    void Tap()
    {
        currentindex++;
        Debug.Log(currentindex);
        if (currentindex >= panels.Length)
        {
            //next scene
            SceneManager.LoadScene("gameplay1");
        }
        else
        {
            UpdatePanel();
        }
    }
    void UpdatePanel()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == currentindex)
            {
                panels[i].SetActive(true);
            }
            else
                panels[i].SetActive(false);
        }
    }
    private void OnDestroy()
    {
        MobileInput.instance.ON_Tap -= Tap;
    }
}
