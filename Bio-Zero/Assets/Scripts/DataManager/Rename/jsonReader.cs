using System.Collections.Generic;
using DataManager.Data;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class jsonReader : MonoBehaviour
{
    private List<InfoGameData> dataPlayerList = new List<InfoGameData>();
    
    void Awake()
    {
        // Ottieni tutti i file JSON nella cartella "Resources"
        string[] jsonFilePaths = Directory.GetFiles(Application.persistentDataPath, "*.game");

        // Itera attraverso i file JSON e leggi i dati
        foreach (string jsonFilePath in jsonFilePaths)
        {
            // Leggi il contenuto del file JSON
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserializza il contenuto del file JSON nella classe InfoGameData utilizzando Newtonsoft.Json
            InfoGameData dataInfo = JsonConvert.DeserializeObject<InfoGameData>(jsonContent);

            // Aggiungi i dati del singolo file corrente alla lista generale
            dataPlayerList.Add(dataInfo);
        }
    }


    public List<InfoGameData> getPlayerList()
    {
        return dataPlayerList;
    }

}