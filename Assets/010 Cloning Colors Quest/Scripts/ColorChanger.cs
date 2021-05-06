// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._010_Cloning_Colors_Quest.Scripts
{
    public class ColorChanger : MonoBehaviour
    {
        private SpriteRenderer mySpriteRenderer;

        void Awake()
        {
            mySpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {

        }
    }
}
