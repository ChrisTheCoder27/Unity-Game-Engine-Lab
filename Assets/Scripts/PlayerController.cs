using Chapter.Singleton;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    CharacterController controller;

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

    void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
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
    }
}

