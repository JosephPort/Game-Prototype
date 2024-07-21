using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public void SceneLoadedIn(){
        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 0, 0.5f).setOnComplete(() => {
            Destroy(gameObject);
        }).setFrom(1);
    }

    public void SceneLoadedOut(string sceneName){
        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 1, 0.5f).setOnComplete(() => {
            SceneManager.LoadScene(sceneName);
        }).setFrom(0);
    }
}
