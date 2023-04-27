using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("File Storage Config")] 
    [SerializeField] private string fileName;
    
    private InfoGameData infoPlayer;
    private List<InterfaceDataManager> dataObjects;
    private FileDataHandler dataHandler;
    
    public static DataManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("DataManager instance not valid!");
        }

        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataObjects = FindAllDataObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.infoPlayer = new InfoGameData();
    }
    
    public void LoadGame()
    {
        this.infoPlayer = dataHandler.Load();
        
        if (this.infoPlayer == null)
        {
            NewGame();
        }

        foreach (InterfaceDataManager singleDataObject in dataObjects)
        {
            singleDataObject.LoadData(infoPlayer);
        }
    }

    public void SaveGame()
    {
        foreach (InterfaceDataManager singleDataObject in dataObjects)
        {
            singleDataObject.SaveData(ref infoPlayer);
        }
        
        dataHandler.Save(infoPlayer);
        
    }

    private List<InterfaceDataManager> FindAllDataObjects()
    {
        IEnumerable<InterfaceDataManager> dataObjectsEnumerable = FindObjectsOfType<MonoBehaviour>()
            .OfType<InterfaceDataManager>();

        return new List<InterfaceDataManager>(dataObjectsEnumerable);
    }
    
}
