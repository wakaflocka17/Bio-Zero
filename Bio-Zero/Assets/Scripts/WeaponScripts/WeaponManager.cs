using Cinemachine;
using Player.ActionState;
using Player.AimStates;
using Player.Info;
using UnityEngine;

namespace WeaponScripts
{
    public class WeaponManager : MonoBehaviour
    {
        [Header("Fire Rate")]
        [SerializeField] float fireRate;
        private float fireRateTimer;
        [SerializeField] bool semiAuto;

        [Header("Bullet Properties")]
        [SerializeField] GameObject bullet;
        [SerializeField] Transform barrelPos;
        [SerializeField] float bulletVelocity;
        [SerializeField] int bulletsPerShot;
        public float damage = 20;
        [SerializeField] AimStateManager aim;

        [SerializeField] AudioClip gunShot;
        [HideInInspector] public AudioSource audioSource;
        [HideInInspector] public WeaponAmmo ammo;

        [SerializeField] ActionStateManager actions;

        [SerializeField] CinemachineVirtualCamera vCam;
        [HideInInspector] public float hipFov;
        [HideInInspector] public float currentFov;
        public float fovSmoothSpeed = 1f;

        Light muzzleFlashlight;
        ParticleSystem gunShotParticles;
        float lightIntensity;
        [SerializeField] float lightReturnSpeed = 20;
        [SerializeField] CharacterHealth playerHealth;

        Rigidbody rb;
        MeshCollider coll;
        public Transform player, weapons, fpsCam;

        public float pickUpRange;
        public float dropForwardForce, dropUpwardForce;
        public bool equipped;
        private static bool slotFull;

        [HideInInspector] public bool isArmed;

        [SerializeField] public CheatsManager cheatController;

        // Start is called before the first frame update
        private void Start()
        {

            hipFov = vCam.m_Lens.FieldOfView;
            audioSource = GetComponent<AudioSource>();
            ammo = GetComponent<WeaponAmmo>();
            muzzleFlashlight = GetComponentInChildren<Light>();
            lightIntensity = muzzleFlashlight.intensity;
            muzzleFlashlight.intensity = 0;
            gunShotParticles = GetComponentInChildren<ParticleSystem>();
            fireRateTimer = fireRate;
            rb = GetComponent<Rigidbody>();
            coll = GetComponent<MeshCollider>();

            if(!equipped)//Setup if (lequipped)
            {
                rb.isKinematic = false;
                coll.isTrigger = false;
            }
        
            else
            {
                this.enabled = true;
                rb.isKinematic = true;
                coll.isTrigger = true;
                slotFull = true;
            }
        
        }

        // Update is called once per frame
        private void Update()
        {
            if(actions.weapons.Count >= 3)
                slotFull = true;
            else 
                slotFull = false;


            if(ShouldFire()) 
            {
                vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, currentFov, fovSmoothSpeed * Time.deltaTime);
                Fire();
            }

            Vector3 distanceToPlayer = player.position - transform.position;
            if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) 
            {
                PickUp();
            }
       
            muzzleFlashlight.intensity = Mathf.Lerp(muzzleFlashlight.intensity, 0, lightReturnSpeed * Time.deltaTime);
        }

        bool ShouldFire()
        {
            fireRateTimer += Time.deltaTime;

            if(!this.equipped)
                return false;

            if(ammo.currentAmmo == 0) 
                return false;
            
            if(playerHealth.health <= 0)
                return false;

            if(fireRateTimer < fireRate) 
                return false;
            if(actions.currentState == actions.Reload) return false;

            if(semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) 
                return true;

            if(!semiAuto && Input.GetKey(KeyCode.Mouse0)) 
                return true;
        
            return false;
        }

        void Fire()
        {
            fireRateTimer = 0;

            if (!cheatController.cheatInfiniteAmmo.isOn)
            {
                ammo.currentAmmo--;
                ammo.textCurrentAmmo.text = ammo.currentAmmo.ToString(); //Ammo TextProUGui
            }
            
            TriggerMuzzleFlash();
            barrelPos.LookAt(aim.aimPos);
            
        
            for(int i = 0; i < bulletsPerShot; i++)
            {
                audioSource.PlayOneShot(gunShot);
                GameObject currentBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);

                Bullet bulletScript = currentBullet.GetComponent<Bullet>();
                bulletScript.weapon = this;
                Rigidbody rigidbody = currentBullet.GetComponent<Rigidbody>();
                rigidbody.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
            }
        }

        void TriggerMuzzleFlash()
        {
            gunShotParticles.Play();
            muzzleFlashlight.intensity = lightIntensity;
        }

        public void PickUp()
        {
            equipped = true;
        
            transform.SetParent(weapons);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;

            //Make Rigidbody kinematic and BoxCollider a trigger
            rb.isKinematic = true;
            coll.isTrigger = false;
            if(actions.weapons.Count == 0)
            {
                gameObject.SetActive(true);
            }
            else
                gameObject.SetActive(false);
            actions.weapons.Add(this);
            
        }

        public void Drop()
        {
            if(equipped) 
            {
                Debug.Log("drop");
                equipped = false;
            
                transform.SetParent(null);

                rb.isKinematic = false;
                coll.isTrigger = false;

                rb.velocity = player.GetComponent<CharacterController>().velocity;
                //AddForce
                rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
                rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

                float random = Random.Range(-1f, 1f);
                rb.AddTorque(new Vector3(random, random, random) * 10);

                //this.enabled = false; 
            }
        }


    }
}