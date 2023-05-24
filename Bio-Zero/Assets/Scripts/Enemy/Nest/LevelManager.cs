using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> nestes;
    [SerializeField] private GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (GameObject g in nestes)
        {
           if(g.activeSelf)
               break;
            else
                i++;
        }

        if(i == nestes.Count)
            portal.SetActive(true);
    }
}
