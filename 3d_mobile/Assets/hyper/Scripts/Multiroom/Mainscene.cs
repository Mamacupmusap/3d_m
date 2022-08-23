using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainscene : MonoBehaviour
{
    List<AsyncOperation> sceneToLoad = new List<AsyncOperation>();

    public void Startgame()
    {
        sceneToLoad.Add(SceneManager.LoadSceneAsync("03_MultiRoom_main"));
        //sceneToLoad.Add(SceneManager.LoadSceneAsync("Multiroom_part1"), LoadSceneMode.Additive);
        //SceneManager.LoadScene("Multiroom_part1", LoadSceneMode.Additive);
    }

}    
