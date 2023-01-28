using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform player, camPivot, cam;
    [SerializeField] private float rotationX, rotationY;

    private Vector3 direction;
    private Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        direction = player.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized); // todo frame, vai capturar o andado do jogador e salvar em 'direction'

        rotationX = Mathf.Lerp(rotationX, Input.GetAxisRaw("Mouse X") * 2, 100 * Time.deltaTime); //rotacao da cam no eixo X(ou seja, olhar pra cima e pra baixo)

        rotationY = Mathf.Clamp(rotationY - (Input.GetAxisRaw("Mouse Y") * 2 * 100 * Time.deltaTime), -30, 30);//rotacao da cam no eixo Y (ou seja, olhar para a esquerda e direita!)

        player.Rotate(0, rotationX, 0, Space.World);

        cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.Euler(rotationY * 2, player.eulerAngles.y, 0), 100 * Time.deltaTime);

        camPivot.position = Vector3.Lerp(camPivot.position, player.position, 10 * Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * 10 * Time.fixedDeltaTime);
    }
}
