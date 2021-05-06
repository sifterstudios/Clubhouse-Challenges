// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._007_Mining_Quest.Scripts
{
    public class Pickaxe : MonoBehaviour
    {
        private PlayerMovement player;

        private void Start()
        {
            player = FindObjectOfType<PlayerMovement>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Rock"))
            {
                player.SetTargetBlock(other.gameObject);
            }
        }
    }
}
