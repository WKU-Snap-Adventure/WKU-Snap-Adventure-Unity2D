using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLoader : MonoBehaviour
{
    public GameObject LoadedPanel;
    public Animator LoadedPanelAnimator;
    public float transitionTime = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        LoadedPanel.SetActive(false);
    }

    public void LoadPanel(){
        LoadedPanel.SetActive(true);
        
        LoadedPanelAnimator.SetTrigger("LoadPanel");
    }

    public void ClosePanel(){        
        LoadedPanelAnimator.SetTrigger("ClosePanel");

        StartCoroutine(WaitForClosePanelAnimationAndClosePanel());
    }

    IEnumerator WaitForClosePanelAnimationAndClosePanel(){

        yield return new WaitForSeconds(transitionTime);

        LoadedPanel.SetActive(false);
    }


}
