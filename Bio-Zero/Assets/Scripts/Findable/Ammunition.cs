using UnityEngine;

public class Ammunition : MonoBehaviour
{
    private int extraAmmo = 60;
    [SerializeField] GameObject boxCover;
    [SerializeField] BoxCollider coll;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<WeaponAmmo>())
        {
            WeaponAmmo ammo = other.GetComponent<WeaponAmmo>();

            ammo.AddAmmo(extraAmmo);
            boxCover.SetActive(false);
            coll.isTrigger = false;

        }

        this.enabled = false;
        coll.enabled = false;
    }
}