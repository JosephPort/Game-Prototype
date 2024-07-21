using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveHandler : MonoBehaviour
{
    public SaveData saveData;
    
    void Awake(){
        DontDestroyOnLoad(gameObject);

        saveData = SaveManager.Load();
    }

    void Start()
    {
        SceneManager.LoadScene("Main");
    }
}
