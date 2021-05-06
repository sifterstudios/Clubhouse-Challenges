using UnityEngine;
using UnityEngine.SceneManagement;

namespace SIFTER._003_Trail_Blazer_Quest.Scripts
{
    public class DeathPlane : MonoBehaviour
    {
        private void OnTriggerEnter() 
        {
            SceneManager.LoadScene(0);
        }
    }
}
