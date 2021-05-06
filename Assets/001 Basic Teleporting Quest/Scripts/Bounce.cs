using System;
using UnityEngine;

// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

namespace SIFTER._001_Basic_Teleporting_Quest.Scripts
{
    public class Bounce : MonoBehaviour
    {
        [SerializeField] float jumpForce = 1000f;

    

        void OnTriggerEnter(Collider other)
        {
            JumpyJumpy(other);
        }

        void JumpyJumpy(Collider other)
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.AddRelativeForce(0,jumpForce,0);
        }
    }
}
