using UnityEngine;
using Cinemachine;

public class CameraRecoil : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float recoilDuration = 0.2f;
    [SerializeField] private float recoilIntensity = 2f;
    
    private float recoilTimer;

    void Start()
    {
        // Inizializza il timer del rinculo
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    
    void Update()
    {
        // Verifica se è attivo il rinculo della telecamera
        if (recoilTimer > 0)
        {
            // Riduci gradualmente l'intensità del rinculo nel tempo
            float recoilProgress = 1f - (recoilTimer / recoilDuration);
            float currentRecoil = Mathf.Lerp(recoilIntensity, 0f, recoilProgress);
            
            // Applica il rinculo alla telecamera
            virtualCamera.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.y = currentRecoil;
            
            // Riduci il timer del rinculo
            recoilTimer -= Time.deltaTime;
        }
    }
    
    public void ApplyRecoil()
    {
        // Attiva il rinculo della telecamera
        recoilTimer = recoilDuration;
    }
}