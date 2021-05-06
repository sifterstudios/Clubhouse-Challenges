// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;
using UnityEngine.SceneManagement;

namespace SIFTER._007_Mining_Quest.Scripts
{
    public class GameOver : MonoBehaviour
    {
        GameHandler gameHandler;

        private void Start()
        {
            gameHandler = FindObjectOfType<GameHandler>();
        }


        public void RetryButton()
        {
            gameHandler.resetFoodCount();
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
}
