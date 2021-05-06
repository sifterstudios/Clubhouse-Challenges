// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;
using UnityEngine.UI;

namespace SIFTER._009_Toady_Froggerson_Quest.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Text scoreText;
        int score;

        const string vehicleTag = "Vehicle";
        const string tileTag = "Tile";

        void Start()
        {
            scoreText.text = "Score: " + score;
        }

        //TODO - Develop a scoring system (Ideas: count how many tiles have passed, how far the player has moved through in the world, or how long they've survived, etc)
    
        void OnTriggerEnter(Collider other)
        {
            //TODO - Handle player getting hit by a vehicle (Ideas: reload the level, add a "lose" screen to show the score, etc.)
        }

    }
}
