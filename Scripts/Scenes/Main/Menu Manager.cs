using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        SceneLoading sceneLoading = FindObjectOfType<SceneLoading>();

        sceneLoading.SceneLoadedIn();
    }

    public void SwapScene(string sceneName)
    {
        GameObject sceneLoading = Instantiate(Resources.Load<GameObject>("Loading Panel"), GameObject.Find("Instantiated").transform);
        sceneLoading.GetComponent<SceneLoading>().SceneLoadedOut(sceneName);
    }
}
