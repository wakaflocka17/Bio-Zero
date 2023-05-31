using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponScripts;
using Player.ActionState;

public class EnemyShoot : MonoBehaviour
{
    Animator animator;
    [SerializeField] private GameObject bullet;
    private int damage = 10;
    private float fireRate = 3;
    [SerializeField] private GameObject barrelPos;
    private GameObject currentBullet;
    private float lastFireBullet = 4;
    private float bulletVelocity = 100;
    [SerializeField] private ActionStateManager player;
     [SerializeField] AudioClip gunShotSound;
        [HideInInspector] public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("isAttack"))
        {
            RotateToPlayer();
            lastFireBullet += Time.deltaTime;
            if(lastFireBullet >= 1.2)
            {
                
                Shoot();
                lastFireBullet = 0;
            } 
        }
    }

    private void RotateToPlayer()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        var targetRotation = Quaternion.LookRotation(playerPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100f * Time.deltaTime);
    }

    public void Shoot()
    {

        AudioManager.Instance.PlaySoundEffect(audioSource,gunShotSound);
        currentBullet = Instantiate(bullet, barrelPos.transform.position, barrelPos.transform.rotation);
        Rigidbody rigidbody = currentBullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(barrelPos.transform.forward * bulletVelocity, ForceMode.Impulse);
        // currentBullet = Instantiate(bullet, barrelPos.transform.position, barrelPos.transform.rotation);
    }

    public int getDamage()
    {
        return damage;
    }
}
