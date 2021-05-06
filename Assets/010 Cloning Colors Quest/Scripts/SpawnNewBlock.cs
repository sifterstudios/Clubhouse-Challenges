// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._010_Cloning_Colors_Quest.Scripts
{
    public class SpawnNewBlock : MonoBehaviour
    {
        [SerializeField] GameObject blockPrefab;
        [SerializeField] Transform spawnPosition;

        public void SpawnBlock()
        {
            Instantiate(blockPrefab, spawnPosition.position, Quaternion.identity);
        }
    }
}
