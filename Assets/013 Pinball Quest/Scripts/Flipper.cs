// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using UnityEngine;

namespace SIFTER._013_Pinball_Quest.Scripts
{
    public class Flipper : MonoBehaviour
    {
        HingeJoint2D joint;

        void Start()
        {
            joint = GetComponent<HingeJoint2D>();
        }

        // push space to turn the motor on
        // release space to turn the motor off
        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                joint.useMotor = true;
            }
            else
            {
                joint.useMotor = false;
            }
        }
    }
}
