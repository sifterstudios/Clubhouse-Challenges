// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv  

using UnityEngine;

namespace SIFTER._004_Double_Room_Quest.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float moveSpeed;
        [SerializeField] Rigidbody rb;

        private Vector3 moveDirection;

        void Update()
        {
            ProcessInputs();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void ProcessInputs()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        }

        private void Move()
        {
            rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.z * moveSpeed) * Time.deltaTime;
        }
    }
}
