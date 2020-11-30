using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetSceneByName("UI_Display").isLoaded == false)
        {
            SceneManager.LoadSceneAsync("UI_Display", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadSceneAsync("UI_Display");
        }
    }
}
