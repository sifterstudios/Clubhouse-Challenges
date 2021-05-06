// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._007_Mining_Quest.Scripts
{
    public class FaceMouse : MonoBehaviour
    {
        void Start()
        {
        
        }

        void Update()
        {
            faceMouse();
        }

        private void faceMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new Vector2(transform.position.x - mousePosition.x, transform.position.y - mousePosition.y);

            transform.up = direction;
        }
    }
}
