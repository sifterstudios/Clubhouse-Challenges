// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._017_Spin_Boarder_Quest.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] int baseSpeed = 20;

        Collider2D myCollider;
        Rigidbody2D rb2D;
        SurfaceEffector2D effector2D;

        // Start is called before the first frame update
        void Start()
        {
            effector2D = FindObjectOfType<SurfaceEffector2D>();
            rb2D = GetComponent<Rigidbody2D>();
            myCollider = GetComponent<Collider2D>();
        }

        void Update()
        {

        }

        void FixedUpdate() 
        {
            RotatePlayer();
        }

        void RotatePlayer()
        {
        
        }
    }
}
