using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using TMPro;

namespace Week6
{

    public class PlayerController2D : MonoBehaviour
    {      
        [SerializeField] float speed = 5.0f;
        [SerializeField] float jumpForce;
        [SerializeField] float rotationVertical = 5.0f;
        [SerializeField] float rotationHorizontal = 5.0f;

        private float mouseDeltaX = 0f;
        private float mouseDeltaY = 0f;
        private float cameraRotX = 0f;
        private int rotDir = 0;

        PlayerControllerMappings playerMappings2D;

        InputAction move;
        InputAction fire;
        InputAction jump;
        InputAction look;

        Rigidbody rb;

        [SerializeField] Transform HealthCounterPrefab;
        private int health = 3;

        [SerializeField] TextMeshProUGUI CoinCounter;
        private int coins = 0;

        [SerializeField] GameObject GameOverPopup;
        public static UnityEvent GameOver = new UnityEvent();
        public static UnityEvent ResetGame = new UnityEvent();

        private float startingPositionX;
        private float startingPositionY;

        private void Awake()
        {
            startingPositionX = gameObject.transform.position.x;
            startingPositionY = gameObject.transform.position.y;

            rb = GetComponent<Rigidbody>();

            playerMappings2D = new PlayerControllerMappings();
            move = playerMappings2D.Player.Move;

            fire = playerMappings2D.Player.Fire;
            fire.performed += Fire;

            jump = playerMappings2D.Player.Jump;
            jump.performed += Jump;

            look = playerMappings2D.Player.Look;

            CoinCounter.text = $"Coins: {coins}";


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
            //HandleHorizontalRotation();
            //HandleVerticalRotation();

        }

        void FixedUpdate()
        {
            Vector2 input = move.ReadValue<Vector2>();
            Vector2 direction = (input.x * transform.right) + (transform.up * input.y);

            transform.position += (Vector3)(Time.deltaTime * speed * direction);
        }

        void HandleHorizontalRotation()
        {
            mouseDeltaX = look.ReadValue<Vector2>().x;

            if (mouseDeltaX != 0)
            {
                rotDir = mouseDeltaX > 0 ? 1 : -1;

                transform.eulerAngles += new Vector3(0, rotationHorizontal * Time.deltaTime * rotDir, 0);
            }
        }

        void HandleVerticalRotation()
        {
            mouseDeltaY = look.ReadValue<Vector2>().y;

            if (mouseDeltaY != 0)
            {
                rotDir = mouseDeltaY > 0 ? -1 : 1;

                cameraRotX += rotationVertical * Time.deltaTime * rotDir;
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
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        public void Damage()
        {
            Debug.Log("Hit");
            
            Transform damage = HealthCounterPrefab.Find($"Health{health}");
            damage.gameObject.SetActive(false);
            health -= 1;

            if (health == 0)
            {
                GameOverPopup.SetActive(true);
                GameOver.Invoke();
            }
            
        }

        public void CollectCoin()
        {
            coins += 1;
            CoinCounter.text = $"Coins: {coins}";
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform.tag == "Spike") Damage();
            if (other.transform.tag == "Coin") CollectCoin();
        }

        public void Reset()
        {
            GameOverPopup.SetActive(false);
            ResetGame.Invoke();
            health = 3;
            coins = 0;
            CoinCounter.text = $"Coins: {coins}";

            for (int i = 1; i <= 3; i++)
            {
                Transform resetHealth = HealthCounterPrefab.Find($"Health{i}");
                resetHealth.gameObject.SetActive(true);
            }
            gameObject.transform.position = new Vector3(startingPositionX, startingPositionY, 0);
        }
    }
}
