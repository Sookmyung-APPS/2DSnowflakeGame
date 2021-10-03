﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    public static string loadScene;
    public static int loadType;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }
    public static void LoadSceneHandle(string _name, int _loadType)
    {
        loadScene = _name;
        loadType = _loadType;
        SceneManager.LoadScene("Loading");
    }


    IEnumerator LoadScene()
    {
        yield return null;
        
        AsyncOperation operation = SceneManager.LoadSceneAsync("SampleScene");
        //AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");
        operation.allowSceneActivation = false;
        

        while (!operation.isDone)
        {
            yield return null;

            //if (loadType == 0)
            //    Debug.Log("새게임");
            //else if (loadType == 1)
            //    Debug.Log("헌게임");

            if(progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value,0.9f, Time.deltaTime*0.5f);
            }
            else if(operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            if(progressbar.value >= 1f)
            {
                loadtext.text = "스페이스 바를 누르세요";
            }

            if (Input.GetKeyDown(KeyCode.Space)&&progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

        }

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
