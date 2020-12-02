using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetSceneByName("HUD_Display").isLoaded == false)
        {
            SceneManager.LoadSceneAsync("HUD_Display", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadSceneAsync("HUD_Display");
        }
    }
}
