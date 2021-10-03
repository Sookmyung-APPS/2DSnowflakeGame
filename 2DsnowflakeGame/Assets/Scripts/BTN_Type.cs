using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//메인,옵션 화면 버튼
public class BTN_Type : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BtnType currentType;

    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;

    public void Start()
    {
        defaultScale = buttonScale.localScale;
    }
    private bool muted = false;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BtnType.New:
                PlayerPrefs.DeleteAll();
                SceneLoad.LoadSceneHandle("SampleScene", 0);
                //Debug.Log("새게임");
                
                break;
            /*case BtnType.Continue:
                SceneLoad.LoadSceneHandle("SampleScene", 1);
                Debug.Log("이어하기");
                break;*/
            case BtnType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupOff(mainGroup);
                
                break;
            case BtnType.Sound:
                if (muted == false)
                {
                    muted = true;
                    AudioListener.pause = true;
                }
                else
                {
                    muted = false;
                    AudioListener.pause = false;
                }
                
                break;

                
                
                break;
            case BtnType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupOff(optionGroup);
                Debug.Log("뒤로가기");
                break;
            case BtnType.Quit:
                Application.Quit();
                Debug.Log("앱종료");
                break;
        }

    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

}
