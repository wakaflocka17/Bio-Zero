using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackManager : MonoBehaviour
{

    [SerializeField] List<GameObject> barrackList;
    private bool canContinue = false;
    private int index = 0;
    [SerializeField] private GameObject miniboss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RemoveNullBarrack();
        if(barrackList.Count == 0 && index == 0)
        {
            Debug.Log("Siamo dentro AllNull() nell'Update");
            index++;
            canContinue = true;
            miniboss.SetActive(true);
        }
    }

    private void RemoveNullBarrack()
    {
        foreach(GameObject barrack in barrackList)
        {
            if(barrack == null)
            {
                barrackList.Remove(barrack);
            }
        }
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
