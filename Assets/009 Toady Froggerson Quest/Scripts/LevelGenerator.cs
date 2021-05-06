// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._009_Toady_Froggerson_Quest.Scripts
{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] ObjectPool[] objectPools;
        [SerializeField] int worldSize = 10;
        [SerializeField] float tileDepth = 10f;
        [SerializeField] TileDespawner tileDespawner;

        Mover mover;

        void Awake()
        {
            mover = FindObjectOfType<Mover>();
        }

        void Start()
        {
            //Sets up the initial tiles in the world.
            for (int i = -1; i < worldSize; i++)
            {
                GenerateTile(tileDepth * i);
            }
        }

        public void DisableTile(GameObject obj)
        {
            //Return the tile to the pool
            obj.SetActive(false);

            //Stop the tile moving
            mover.RemoveMovableObject(obj);

            //Create a new replacement tile for the far end of the level
            GenerateTile(tileDepth * worldSize + (tileDespawner.transform.position.z + (2 * tileDepth)));
        }

        void GenerateTile(float zOffset)
        {
            //Select a tile from a random pool
            int selectedPool = Random.Range(0, objectPools.Length);

            GameObject poolObject = objectPools[selectedPool].EnableObjectInPool(tileDepth);

            //If there was not availalbe tile in the pool, naively select the first one you can find from another pool
            if (poolObject == null)
            {
                foreach (ObjectPool pool in objectPools)
                {
                    poolObject = pool.EnableObjectInPool();
                    if (poolObject != null) { break; }
                }
            }

            if(poolObject != null)
            {
                //Align the center of the tile to the player
                poolObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOffset);

                //Make the tile moveable
                mover.AddMovableObject(poolObject);
            }
        }
    }
}
