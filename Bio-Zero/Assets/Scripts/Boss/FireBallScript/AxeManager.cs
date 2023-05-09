using UnityEngine;

public class AxeManager : MonoBehaviour
{
    [Header("Fire Rate")]
    private float fireRateTime;
    //private float initFireRateTime = 3.0f;

    [Header("FireBall Properties")]
    private float velocity;
    public float damage;
    [SerializeField] GameObject fireball;
    [SerializeField] Transform shootFirePos;
    [SerializeField] AudioClip fireballAudio;
    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public WeaponAmmo ammo;
    
    [Header("Player Properties")]
    [SerializeField] CharacterHealth playerHealth;
    
    [Header("Boss Properties")]
    BossHealth bossHealth;

    // Start is called before the first frame update
    /* void Start()
    {
        velocity = 30.0f;
        damage = 20.0f;

        bossHealth = GetComponent<BossHealth>();

        fireRateTime = initFireRateTime;
    } */

    // Update is called once per frame
    void Update()
    {
        
    }

}