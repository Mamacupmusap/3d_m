using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string filename;
    [SerializeField] private bool useEncryption;

    private GameData gameData;
    private List<IDataPersistance> dataPersistancesObjects;

    //fileDataHandler
    private FileDataHandler dataHandler;

    public static DataPersistManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Found more thn one Data Persistence Manager in the scene");
        }
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //load data using data handler
        this.gameData = dataHandler.Load();

        //no data found , start new game
        if(this.gameData == null)
        {
            Debug.Log("No data found , start new game");
            NewGame();
        }

        //load data to other script
        foreach(IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        //update data to other script
        foreach (IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }

        //save data using data handler
        dataHandler.Save(gameData);
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, filename, useEncryption);
        this.dataPersistancesObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
