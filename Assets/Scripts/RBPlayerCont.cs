using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBPlayerCont : MonoBehaviour
{
    Rigidbody rb;
    public GameObject Cam;
    public float speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 look;       
        look.x = Input.GetAxisRaw("Mouse X");
        look.y = Input.GetAxisRaw("Mouse Y");

        Cursor.lockState = CursorLockMode.Locked;

        this.transform.Rotate(0, look.x, 0);
        Cam.transform.Rotate(look.y * -1f, 0, 0);
        
        Vector3 newMove;

        Vector3 newMoveX = Input.GetAxisRaw("Horizontal") * Cam.transform.right * speed;
        Vector3 newMoveY = Input.GetAxisRaw("Vertical") * Cam.transform.forward * speed;
        Vector3 newMoveZ = Vector3.zero;

        newMove = newMoveX + newMoveY + newMoveZ;
        newMove.y = rb.velocity.y;
        rb.velocity = newMove;
    }
}
