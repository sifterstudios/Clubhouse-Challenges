using UnityEngine;

namespace SIFTER._001_Basic_Teleporting_Quest.Scripts.First_person_controller
{
    public class FirstPersonMovement : MonoBehaviour
    {
        public float speed = 5;
        Vector2 _velocity;


        void FixedUpdate()
        {
            _velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            _velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(_velocity.x, 0, _velocity.y);
        }
    }
}
