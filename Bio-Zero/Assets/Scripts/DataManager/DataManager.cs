using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [Header("File Storage Config")] 
    [SerializeField] private string fileName;

    [Header("User Input Text")] 
    [SerializeField] public GameObject textNickname;
    private string nickname;

    private InfoGameData infoPlayer;
    private List<InterfaceDataManager> dataObjects;
    private FileDataHandler dataHandler;
    
    public static DataManager instance { get; private set; }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        else
        {
            instance = this; 
        }
        
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        nickname = textNickname.ToString();
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataObjects = FindAllDataObjects();
        LoadGame(nickname);
    }

    public void NewGame(string nickname)
    {
        infoPlayer = new InfoGameData(nickname);
    }
    
    public void LoadGame(string nickname)
    {
        infoPlayer = dataHandler.Load();
        
        if (infoPlayer == null)
        {
            NewGame(nickname);
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
