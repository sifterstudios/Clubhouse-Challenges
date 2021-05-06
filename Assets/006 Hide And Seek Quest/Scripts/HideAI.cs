// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SIFTER._006_Hide_And_Seek_Quest.Scripts
{
    public class HideAI : MonoBehaviour
    {
        // Start is called before the first frame update
        IEnumerator Start()
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();

            foreach (Vector3 point in RandomPoints(1, 100))
            {
                Debug.Log("Moving to new location");
                agent.SetDestination(point);

                while (NavMeshAgentIsMoving())
                {
                    yield return null;
                }
            }
        }

        IEnumerable<Vector3> RandomPoints(float interval, float maxDistance)
        {
            Vector3 location = transform.position;
            for (float distance = interval; distance < maxDistance; distance += interval)
            {
                Vector2 randomCircle = Random.insideUnitCircle * distance;
                Vector3 randomOffset = new Vector3(randomCircle.x, 0, randomCircle.y);
                yield return location + randomOffset;
            }
        }

        bool NavMeshAgentIsMoving()
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            return agent.pathPending || agent.remainingDistance > 0;
        }

        bool CanBeSeenByPlayer(Vector3 point)
        {
            Vector3 direction = point - Camera.main.transform.position;
            float distance = direction.magnitude;
            if (Physics.Raycast(Camera.main.transform.position, direction, distance))
            {
                return false;
            }
            return true;
        }
    }
}
