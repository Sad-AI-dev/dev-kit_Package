using UnityEngine;

namespace DevKit {
    [AddComponentMenu("DevKit/Behaviours/Mover")]
    [RequireComponent(typeof(Rigidbody))]
    public class Mover : MonoBehaviour
    {
        [Header("Settings")]
        public Vector3 moveDirection;
        public float moveSpeed = 1f;
        [SerializeField] private bool moveOnStart = true;

        //states
        private bool moving;

        //external
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            moveDirection.Normalize(); //normalize direction

            if (moveOnStart) StartMove();
        }

        //----------states------------
        public void StartMove()
        {
            moving = true;
        }

        public void StopMove()
        {
            moving = false;
        }

        //----------movement----------
        private void FixedUpdate()
        {
            if (moving) Move();
        }

        private void Move()
        {
            Vector3 speed = moveDirection * (100 * moveSpeed * Time.deltaTime);
            rb.velocity = transform.right * speed.x + transform.up * speed.y + transform.forward * speed.z; //convert to local space
        }
    }
}
