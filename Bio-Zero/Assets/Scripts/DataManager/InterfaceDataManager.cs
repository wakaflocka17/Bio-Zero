using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceDataManager
{
    void LoadData(InfoGameData infoPlayer);
    void SaveData(ref InfoGameData infoPlayer);
}
