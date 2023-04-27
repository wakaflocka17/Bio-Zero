using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class FileDataHandler
{
    private string directoryPath;
    private string fileName;

    public FileDataHandler(string directoryPath, string fileName)
    {
        this.directoryPath = directoryPath;
        this.fileName = fileName;
    }

    public InfoGameData Load()
    {
        string fullPath = Path.Combine(directoryPath, fileName);
        InfoGameData infoGameDataLoaded = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                infoGameDataLoaded = JsonUtility.FromJson<InfoGameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error during to load data from file!");
            }
        }

        return infoGameDataLoaded;
    }

    public void Save(InfoGameData infoPlayer)
    {
        //Path.Combine is equivalent to concatenate a "/" between directoryPath and fileName
        string fullPath = Path.Combine(directoryPath, fileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //Serialize the game data object into File Json
            string dataPlayerStore = JsonUtility.ToJson(infoPlayer, true);
            
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataPlayerStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error during to save data to file!");
        }

    }
}
