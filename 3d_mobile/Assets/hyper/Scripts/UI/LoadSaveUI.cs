using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveUI : MonoBehaviour
{
    public void OnNewGameClicked()
    {
        DataPersistManager.instance.NewGame();
    }

    public void OnLoadGameClicked()
    {
        DataPersistManager.instance.LoadGame();
    }
    public void OnSaveGameClicked()
    {
        DataPersistManager.instance.SaveGame();
    }
}
