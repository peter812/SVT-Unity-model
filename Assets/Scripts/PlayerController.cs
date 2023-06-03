using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController controller;
    public float moveSpeed;
    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 look;       
        look.x = Input.GetAxisRaw("Mouse X");
        look.y = Input.GetAxisRaw("Mouse Y");

        Cursor.lockState = CursorLockMode.Locked;

        this.transform.Rotate(0, look.x, 0);
        Camera.transform.Rotate(look.y * -1f, 0, 0);

        Vector3 MoveX = Vector3.zero;
        MoveX = Input.GetAxisRaw("Horizontal") * moveSpeed * this.transform.right;
        Vector3 MoveY = Vector3.zero;
        MoveY = Vector3.zero;
        Vector3 MoveZ = Vector3.zero;
        MoveZ = Input.GetAxisRaw("Vertical") * moveSpeed * this.transform.forward;
        
        Vector3 newMove;
        newMove = MoveX + MoveY + MoveZ;
        newMove.y = 0f;

        controller.Move(newMove);
    }
}
