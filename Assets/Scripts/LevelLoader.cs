using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public int toWhichLevelIndex;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(toWhichLevelIndex));
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
