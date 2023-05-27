using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.ActionState;

public class PoisonScript : MonoBehaviour
{

    [SerializeField] private GameObject portal;
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
            portal.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
