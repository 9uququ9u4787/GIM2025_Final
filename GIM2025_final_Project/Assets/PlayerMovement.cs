using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController playerController;
    Transform playerTransform;
    public Transform cameraTransform;
    float cameraRot;
    Animator animator;

    public float playerSpeed;

    public float mouseSensitivity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        playerTransform = transform;
        animator = GetComponent<Animator>(); // Animator ������Ʈ ��������
        

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        MouseLook();
    }

    void PlayerMove()
    {
        float keyX = Input.GetAxis("Horizontal");
        float keyZ = Input.GetAxis("Vertical");
        Vector3 move = playerTransform.right * keyX + playerTransform.forward * keyZ;
        playerController.Move(move * Time.deltaTime * playerSpeed);
        
        // �̵� �ӵ��� ���� �ִϸ��̼� Speed �� ����
    float speed = new Vector2(keyX, keyZ).magnitude;
    animator.SetFloat("Speed", speed); // �Ķ���� �̸��� Animator�� "Speed"
    }

    void MouseLook(){
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity;
        
        cameraRot = cameraRot - mouseY;
        cameraRot = Mathf.Clamp(cameraRot, -90f, 90f);
        cameraTransform.localEulerAngles = Vector3.right * cameraRot;
        playerTransform.Rotate(Vector3.up * mouseX);

    }
}
