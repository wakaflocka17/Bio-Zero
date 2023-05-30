using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player.ActionState;

public class PortalScript : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] AudioClip portalSound;
    [HideInInspector] public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        AudioManager.Instance.PlaySoundEffect(audioSource,portalSound);


        if(other.gameObject.GetComponent<ActionStateManager>())
            SceneManager.LoadScene(sceneName);
    }
}
