using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackManager : MonoBehaviour
{

    [SerializeField] List<GameObject> barrackList;
    private bool canContinue = false;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AllNull() && index == 0)
        {
            index++;
            canContinue = true;
        }
    }

    private bool AllNull()
    {
        foreach(GameObject barrack in barrackList)
        {
            if(barrack != null)
            {
                return false;
            }
        }
        print("All null");
        return true;
    }

    public bool GetContinue()
    {
        return canContinue;
    }

    public void setContinue(bool value)
    {
        canContinue = value;
    }
}
