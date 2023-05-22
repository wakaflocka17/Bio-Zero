using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player.ActionState
{
    public class HelicopterComponent : MonoBehaviour
    {
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
                    ActionStateManager actions = other.GetComponent<ActionStateManager>();
                    actions.componentIndex++;
                    this.gameObject.SetActive(false);
                }
            }
    }
}
