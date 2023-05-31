using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.ActionState;

public class KeyScript : MonoBehaviour
{

    private bool canContinue = false;
    public bool isMiniBossDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<ActionStateManager>())
        {
            canContinue = true;
            this.gameObject.SetActive(false);
        }
    }

    public bool GetContinue()
    {
        return canContinue;
    }
}
