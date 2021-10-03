using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//플레이에서 메인갈때 버튼
public class playbutton : MonoBehaviour
{
    public BtnType11 currentType;

    public void OnBtnnClick()
    {
        switch (currentType)
        {
            case BtnType11.Main:
                SceneManager.LoadScene("MainMenu", 0);
                //SceneLoad.LoadSceneHandle("MainMenu", 0);
                //Debug.Log("새게임");
                break;

               
            
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
