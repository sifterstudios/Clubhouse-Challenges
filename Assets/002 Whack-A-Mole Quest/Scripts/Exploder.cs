using UnityEngine;

namespace SIFTER.Scripts
{
    public class Exploder : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            print("Aww, you got me");
            Destroy(gameObject);         
        }
    }
}
