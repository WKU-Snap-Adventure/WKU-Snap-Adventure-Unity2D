using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public float waitTime = 1.5f;
    public int toWhichLevelIndex;
    public bool isLoadingScene = false;
    public SceneControl sceneControl; 

    void Awake()
    {
        sceneControl = GameObject.FindObjectOfType<SceneControl>();
        if(sceneControl == null)
        {
            Debug.LogWarning("Did not get SceneControl");
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(toWhichLevelIndex));
        StartCoroutine(SetUI());        
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator SetUI(){
        yield return new WaitForSeconds(waitTime);
        sceneControl.ChangeVisibility();
    }
}
