using DataManager.Data;

namespace DataManager
{
    public interface InterfaceDataManager
    {
        void LoadData(InfoGameData infoPlayer);
        void SaveData(ref InfoGameData infoPlayer);
    }
}
