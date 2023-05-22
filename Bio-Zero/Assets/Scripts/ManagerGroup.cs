using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManagerGroup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public DataManager.DataManager dataM;
    public static ManagerGroup instance { get; set; }
    
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        else
        {
            DontDestroyOnLoad(this);
        }
    }

}
