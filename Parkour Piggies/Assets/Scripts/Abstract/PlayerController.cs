using UnityEngine;

namespace DefaultNamespace
{
    public abstract class PlayerController : MonoBehaviour
    {
        public float walkSpeed;
        public float jumpSpeed;
        public float gravityScale;
        public CameraController camera;
        public float fallSpeed;
        public float lowJumpSpeed;

        public GameObject exit;




    }
}
