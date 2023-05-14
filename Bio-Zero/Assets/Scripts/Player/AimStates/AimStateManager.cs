using Cinemachine;
using Player.Info;
using UnityEngine;

namespace Player.AimStates
{
    public class AimStateManager : MonoBehaviour
    {

        AimBaseState currentState;

        public HipFireState Hip = new HipFireState();
        public AimState Aim = new AimState();

        private float xAxis, yAxis;
        [SerializeField] Transform cam;
        [SerializeField] float mouseSense = 1;

        [HideInInspector] public Animator animator;
        [HideInInspector] public CinemachineVirtualCamera vCam;
        public float adsFov = 40;
        [HideInInspector] public float hipFov;
        [HideInInspector] public float currentFov;
        public float fovSmoothSpeed = 10f;

        public Transform aimPos;
        [SerializeField] public float aimSmoothSpeed = 20;
        [SerializeField] LayerMask aimMask;
        CharacterHealth playerHealth;
    
        // Start is called before the first frame update
        void Start()
        {
            playerHealth = GetComponent<CharacterHealth>();
            vCam = GetComponentInChildren<CinemachineVirtualCamera>();
            hipFov = vCam.m_Lens.FieldOfView;
            animator = GetComponent<Animator>();
            SwitchState(Hip);
        }

        // Update is called once per frame
        void Update()
        {
            if(playerHealth.health > 0)
            {
                xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
                yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSense;
                yAxis = Mathf.Clamp(yAxis, -80, 80);

                vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, currentFov, fovSmoothSpeed * Time.deltaTime);

                Vector2 screenCentre = new Vector2(Screen.width / 2, Screen.height / 2);
                Ray ray = Camera.main.ScreenPointToRay(screenCentre);

                if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
                {
                    aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
                
                }
                currentState.UpdateState(this);
            }

        }

        private void LateUpdate()
        {
            cam.localEulerAngles = new Vector3(yAxis, cam.localEulerAngles.y, cam.localEulerAngles.z);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
        }

        public void SwitchState(AimBaseState state)
        {
            currentState = state;
            currentState.EnterState(this);
        }

        public void setMouseSense(float value)
        {
            mouseSense = value;
        }
    }
}
