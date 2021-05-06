// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._007_Mining_Quest.Scripts
{
    public class Food : MonoBehaviour
    {
        private GameHandler gameHandler;

        private void Start()
        {
            gameHandler = FindObjectOfType<GameHandler>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                gameHandler.updateFood();
            }
        }
    }
}
