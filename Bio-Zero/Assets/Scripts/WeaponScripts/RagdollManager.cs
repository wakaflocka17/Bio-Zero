using UnityEngine;

namespace WeaponScripts
{
    public class RagdollManager : MonoBehaviour
    {
        Rigidbody[] rbs;
        // Start is called before the first frame update
        void Start()
        {
            rbs = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in rbs) rb.isKinematic = true;
        }

        // Update is called once per frame
        public void TriggerRagdoll()
        {
            foreach(Rigidbody rb in rbs) rb.isKinematic = false;
        }
    }
}
