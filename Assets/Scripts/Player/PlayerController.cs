using Chapter.Singleton;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Chapter.Observer
{
    public class PlayerController : Subject
    {
        Rigidbody rb;
        CharacterController controller;
        CameraController cameraController;
        bool isShaking;

        // Movement variables
        Vector2 moveDirection = Vector2.zero;
        [SerializeField] float moveSpeed = 5f;

        Transform cameraTransform;

        // UI variables
        int firewoodCollected;
        [SerializeField] int firewoodNeeded;
        int health;

        // Input actions
        public InputActionAsset InputActions;
        InputAction move;

        public bool GetIsShaking()
        {
            return isShaking;
        }

        void OnEnable()
        {
            InputActions.FindActionMap("Player").Enable();

            if (cameraController)
            {
                Attach(cameraController);
            }
        }

        void OnDisable()
        {
            InputActions.FindActionMap("Player").Disable();

            if (cameraController)
            {
                Detach(cameraController);
            }
        }

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            controller = GetComponent<CharacterController>();
            cameraController = (CameraController)FindFirstObjectByType(typeof(CameraController));
            cameraTransform = Camera.main.transform;

            firewoodCollected = 0;
            health = 100;

            move = InputSystem.actions.FindAction("Move");
        }

        void Update()
        {
            moveDirection = move.ReadValue<Vector2>();
            Vector3 movement = new Vector3(moveDirection.x, 0, moveDirection.y);
            movement = cameraTransform.forward * movement.z + cameraTransform.right * movement.x;
            movement.y = 0f;

            controller.Move(movement * moveSpeed * Time.deltaTime);

            if (health == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (isShaking)
            {
                isShaking = false;
            }
        }

        public void TakeDamage(int damage)
        {
            if (health > 0)
            {
                health -= damage;
            }
            isShaking = true;
            UIManager.Instance.UpdateHealthText(health);

            NotifyObservers();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Firewood"))
            {
                firewoodCollected++;
                UIManager.Instance.UpdateFirewoodText(firewoodCollected);
                if (firewoodCollected == firewoodNeeded)
                {
                    UIManager.Instance.RevealConfirmText();
                }
                other.gameObject.SetActive(false);
            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                TakeDamage(10);
            }
            if (other.gameObject.CompareTag("Finish"))
            {
                Debug.Log("Quitting.");
                Application.Quit();
            }
        }
    }
}
