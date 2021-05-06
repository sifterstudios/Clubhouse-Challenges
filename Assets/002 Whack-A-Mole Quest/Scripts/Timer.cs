using UnityEngine;
using UnityEngine.UI;

namespace SIFTER.Scripts
{
    public class Timer : MonoBehaviour
    {
        Text timerText; 
        float elapsedTime;
    
        void Start()
        {
            timerText = GetComponent<Text>();
        }

        void Update()
        {
        
        }
    }
}
