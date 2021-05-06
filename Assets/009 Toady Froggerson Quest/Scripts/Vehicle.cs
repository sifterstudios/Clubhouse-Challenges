// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._009_Toady_Froggerson_Quest.Scripts
{
    public class Vehicle : MonoBehaviour
    {
        [SerializeField] float speed;

        const string despawnerTag = "Despawner";

        void OnEnable()
        {
            transform.rotation = transform.parent.rotation;
        }

        void Update()
        {
            //TODO - Move the vechicle along the tile (note: the vehicle will already move sideways with the parent tile)
        }

        void OnTriggerEnter(Collider other)
        {
            //TODO - Return the vehicle to the object pool when it reaches the end of the tile
        }
    }
}
