using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DevKit {
    [AddComponentMenu("DevKit/Controllers/3D/Platformer 3D Rigidbody")]
    [RequireComponent(typeof(Rigidbody))]
    public class Platformer3D_Rigidbody : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float topSpeed;
        public float acceleration;
        public float deceleration;
        [Space(10f)]
        public UnityEvent<Vector2> onMoveDirChanged;
        //movement vars
        private Vector2 moveDir = Vector2.zero;
        private float speed;

        [Header("Jump Settings")]
        public float jumpHeight;
        [Space(10)]
        [Range(0, 1f)] public float jumpBufferTime;
        [Range(0, 1f)] public float coyoteTime;
        //jump vars
        private bool grounded;
        private bool canBufferJump;
        private bool canCoyoteJump;

        [Header("Technical Settings")]
        //external components
        public ObjectDetector groundDetector;
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            //ground detection
            if (groundDetector == null) { Debug.LogError("Please assign an object detector on" + transform.name + "!"); }
            else { RegisterDetectorEvents(); }
        }
        private void RegisterDetectorEvents()
        {
            groundDetector.onDetectFirstObject.AddListener(OnTouchGround);
            groundDetector.onLeaveLastObject.AddListener(OnLeaveGround);
        }

        private void FixedUpdate()
        {
            UpdateSpeed();
            Move();
        }

        //---------------------Movement--------------------------------
        public void SetMoveDir(Vector2 input)
        {
            if (input.magnitude > 1f) { input.Normalize(); }
            if (moveDir != input) { onMoveDirChanged?.Invoke(input); }
            moveDir = input;
        }

        private void UpdateSpeed()
        {
            if (moveDir.magnitude > 0.1f) { speed += acceleration; } //accelerate
            else { speed -= deceleration; } //deceleration
            speed = Mathf.Clamp(speed, 0, topSpeed);
        }

        private void Move()
        {
            Vector2 toMove;
            if (moveDir.magnitude > 0.1f) { toMove = moveDir * (speed * Time.fixedDeltaTime * 100); } //don't allow stop through moveDir
            else { toMove = new Vector2(rb.velocity.x, rb.velocity.z).normalized * (speed * Time.fixedDeltaTime); } //use old direction when there is no direct moveDir
            //output result
            Vector3 result = transform.right * toMove.x + transform.forward * toMove.y;
            rb.velocity = new Vector3(result.x, rb.velocity.y, result.z);
        }

        //------------------------Jumping--------------------------
        public void Jump()
        {
            if (grounded || canCoyoteJump) { AddJumpForce(); } //jump or coyote jump
            else if (!canBufferJump) { //tried jump but not grounded? activate jump buffer
                StartCoroutine(BufferJumpCo());
            }
        }

        private void AddJumpForce()
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode.Impulse);
        }

        //-----------timers-----------
        private IEnumerator BufferJumpCo()
        {
            canBufferJump = true;
            yield return new WaitForSeconds(jumpBufferTime);
            canBufferJump = false;
        }

        private IEnumerator CoyoteJumpCo()
        {
            canCoyoteJump = true;
            yield return new WaitForSeconds(coyoteTime);
            canCoyoteJump = false;
        }

        //----------detector event responses----------
        private void OnTouchGround()
        {
            grounded = true;
            if (canBufferJump) { AddJumpForce(); }
        }

        private void OnLeaveGround()
        {
            grounded = false;
            if (rb.velocity.y <= 0f) { StartCoroutine(CoyoteJumpCo()); } //fell off a platform? allow coyote jump
        }
    }
}