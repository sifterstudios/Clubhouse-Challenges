using UnityEngine;

namespace SIFTER._001_Basic_Teleporting_Quest.Scripts.First_person_controller
{
    public class Jump : MonoBehaviour
    {
        [SerializeField]
        GroundCheck groundCheck;
        Rigidbody rigidbody;
        public float jumpStrength = 2;
        public event System.Action Jumped;


        void Reset()
        {
            groundCheck = GetComponentInChildren<GroundCheck>();
            if (!groundCheck)
                groundCheck = GroundCheck.Create(transform);
        }

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        void LateUpdate()
        {
            if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
            {
                rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
                Jumped?.Invoke();
            }
        }
    }
}
