using System.Collections;
using UnityEngine;

// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

namespace SIFTER._001_Basic_Teleporting_Quest.Scripts
{
    public class Teleport : MonoBehaviour
    {
        [SerializeField] Transform teleportTarget;
        [SerializeField] GameObject player;
        [SerializeField] Light areaLight;
        [SerializeField] Light mainWorldLight;

        void Start()
        {
            areaLight.enabled = false;
            mainWorldLight.enabled = false;
        }

        void OnTriggerEnter(Collider other) 
        {
            
            TeleportPlayer();
            // Challenge 3: DeactivateObject();
            // Challenge 4: IlluminateArea();
            StartCoroutine ("BlinkWorldLight");
            // Challenge 6: TeleportPlayerRandom();
        }

        void TeleportPlayer()
        {
            // code goes here
            player.transform.position = teleportTarget.position;
        }

        void DeactivateObject()
        {
            // code goes here 
        }

        void IlluminateArea()
        {
            // code goes here 
        }

        IEnumerator BlinkWorldLight()
        {
        }

        void TeleportPlayerRandom()
        {
            // code goes here... or you could modify one of your other methods to do the job.
        }

    }
}
