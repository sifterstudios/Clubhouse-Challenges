// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._009_Toady_Froggerson_Quest.Scripts
{
    public class VehicleSpawner : MonoBehaviour
    {
        [SerializeField] float minTime = 1f;
        [SerializeField] float meanTime = 5f;
        [SerializeField] ObjectPool[] objectPools;

        float nextSpawnTime;

        void Update()
        {
            if(Time.time > nextSpawnTime)
            {
                SpawnVehicle();
            
                //TODO - Randomly space out the vehicles (Try using something more interesing than just Random.Range(a,b) - maybe exponential distribution for more realistic traffic?)
            }
        }

        void SpawnVehicle()
        {
            //TODO - Spawn a vehicle from a random object pool.
        }
    }
}


