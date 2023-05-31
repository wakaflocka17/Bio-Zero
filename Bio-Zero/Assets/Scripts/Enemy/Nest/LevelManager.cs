using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Nest
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> nestes;
        [SerializeField] private GameObject portal;
        private bool flagAlertPortal;
        private GameObject alertPortal;

        // Start is called before the first frame update
        void Start()
        {
            flagAlertPortal = false;
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
                {
                    i++;
                }
            }

            if (checkNestes(i))
            {
                flagAlertPortal = true;
                portal.SetActive(true);
            }
            
        }

        public bool checkNestes(int index)
        {
            if (index == nestes.Count)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool GetTriggerPortal()
        {
            return flagAlertPortal;
        }
    }
}