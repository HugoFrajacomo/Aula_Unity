using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamera : MonoBehaviour
{
    public float sensibilidadeMouse = 2.0f;  // Ajuste conforme necess�rio
    private Vector2 rota��oMouse = Vector2.zero;


    #region Config. Mouse
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    #endregion

    #region Rota��o da c�mera
    void Update()
    {
        // Obter os movimentos do mouse
        rota��oMouse += new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * sensibilidadeMouse;

        // Limitar a rota��o vertical para evitar problemas de visualiza��o
        rota��oMouse.x = Mathf.Clamp(rota��oMouse.x, -90f, 90f);

        // Aplicar rota��o � c�mera
        transform.localRotation = Quaternion.Euler(rota��oMouse.x, rota��oMouse.y, 0f);
    }
    #endregion

    #region Config mouse afther exit
    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #endregion
}
