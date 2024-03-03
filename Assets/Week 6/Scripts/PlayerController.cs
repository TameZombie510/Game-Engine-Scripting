using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Week6
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float jumpForce;

        [SerializeField] float rotation = 5.0f;

        private float mouseDeltaX = 0f;
        private float mouseDeltaY = 0f;
        private float cameraRotX = 0f;
        private int rotDir = 0;

        PlayerControllerMappings playerMappings;

        InputAction move;
        InputAction fire;
        InputAction jump;
        InputAction look;

        Rigidbody rb;

        private void Awake()
        {
            
        }

        private void OnEnable()
        {
            move.Enable();
            fire.Enable();
            jump.Enable();
            look.Enable();
        }        

        private void OnDisable()
        {
            move.Disable();
            fire.Disable();
            jump.Disable();
            look.Disable();
        }
       
        // Update is called once per frame
        void Update()
        {
            Vector2 input = move.ReadValue<Vector2>();
            float x = (input.x * speed) + transform.position.x;
            float y = transform.position.y;
            float z = (input.y * speed) + transform.position.z;

            transform.position = new Vector3(x, y, z);

        }

        void FixedUpdate()
        {
            Vector2 input = move.ReadValue<Vector2>();
            Vector3 direction = (input.x * transform.right) + (transform.forward * input.y);

            transform.position = transform.position + (direction * speed * Time.deltaTime);
        }

        void HandleHorizontalRotation()
        {
            mouseDeltaX = look.ReadValue<Vector2>().x;

            if (mouseDeltaX != 0)
            {
                rotDir = mouseDeltaX > 0 ? 1 : -1;

                transform.eulerAngles += new Vector3(0, rotation * Time.deltaTime * rotDir, 0);
            }
        }

        void HandleVerticalRotation()
        {
            mouseDeltaY = look.ReadValue<Vector2>().y;

            if (mouseDeltaY != 0)
            {
                rotDir = mouseDeltaY > 0 ? -1 : 1;

                cameraRotX += rotation * Time.deltaTime * rotDir;
                cameraRotX = Mathf.Clamp(cameraRotX, -45f, 45f);

                var targetRotation = Quaternion.Euler(Vector3.right * cameraRotX);


                //Vector3 angle = new Vector3(rotation * Time.deltaTime * rotDir, 0, 0);

                Debug.Log(Camera.main.transform.localRotation.x);

                Camera.main.transform.localRotation = targetRotation;
                //Camera.main.transform.Rotate(angle, Space.Self);

            }
        }

        void Fire(InputAction.CallbackContext context)
        {

        }
        void Jump(InputAction.CallbackContext context)
        {
            Debug.Log("I jumped");
            //rb.AddForce(transform.up * jumpForce)
        }
    }

}
