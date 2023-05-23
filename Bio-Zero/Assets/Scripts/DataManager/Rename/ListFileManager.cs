using System.Collections.Generic;
using DataManager.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListFileManager : MonoBehaviour
{
    public ScrollRect scrollRect;
    private jsonReader jsonReader;
    // Crea un nuovo elemento UI per l'elemento InfoGameData

    public TextMeshProUGUI textNickname;
    public TextMeshProUGUI textLevel;
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textKill;

    void Start()
    {
        jsonReader = GetComponent<jsonReader>();
        addPlayersToScrollRect();
    }

    public void addPlayersToScrollRect()
    {
        List<InfoGameData> tempList = jsonReader.getPlayerList();
        float counterPositionTransform = -126f;
    
        // Rimuovi eventuali elementi esistenti nello Scroll Rect, tranne il primo
        for (int i = scrollRect.content.childCount - 1; i > 0; i--)
        {
            Destroy(scrollRect.content.GetChild(i).gameObject);
        }

        // Ottieni l'oggetto da clonare
        GameObject objectToClone = scrollRect.content.GetChild(0).gameObject;

        // Itera attraverso la lista dataList e crea un elemento UI per ogni elemento
        foreach (InfoGameData data in tempList)
        {
            // Clona l'oggetto solo se necessario
            GameObject clone;
            
            if (counterPositionTransform != -126f)
            {
                clone = Instantiate(objectToClone);
                clone.transform.SetParent(scrollRect.content, false);
                clone.transform.localPosition = new Vector3(0.0f, counterPositionTransform, 0.0f);
            }
            else
            {
                clone = objectToClone;
            }

            textNickname.text = data.nickname;
            textLevel.text = data.numberLevel.ToString();
            textTime.text = data.hours + ":" + data.minutes + ":" + data.seconds;
            textKill.text = data.numberKill.ToString();

            counterPositionTransform -= 220f;
        }
    }



}
