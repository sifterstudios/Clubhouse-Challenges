// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections.Generic;
using UnityEngine;

namespace SIFTER._009_Toady_Froggerson_Quest.Scripts
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float scrollSpeed = 50f;
        List<GameObject> movableObjects = new List<GameObject>();

        void Update()
        {
            //Get the player Input
            float xMove = Input.GetAxisRaw("Horizontal");
            float zMove = Input.GetAxisRaw("Vertical");

            //Prevent the player moving backwards
            if (zMove < 0) { zMove = 0; }

            //Calculate the scroll vector for the moveable objects
            Vector3 normalizedMoveVector = new Vector3(xMove, 0, zMove).normalized;  
            Vector3 scrollVector = new Vector3(-normalizedMoveVector.x * scrollSpeed, 0, -normalizedMoveVector.z * scrollSpeed) * Time.deltaTime;

            //TODO - Translate (move) all moveable objects based on the scoll vector 
        }

        public void AddMovableObject(GameObject obj)
        {
            movableObjects.Add(obj);
        }

        public void RemoveMovableObject(GameObject obj)
        {
            if (movableObjects.Contains(obj))
            {
                movableObjects.Remove(obj);
            }
        }
    }
}
