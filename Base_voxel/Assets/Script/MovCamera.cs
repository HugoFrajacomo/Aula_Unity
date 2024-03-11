using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamera : MonoBehaviour
{
    public float sensibilidadeMouse = 2.0f;  // Ajuste conforme necessário
    private Vector2 rotaçãoMouse = Vector2.zero;


    #region Config. Mouse
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    #endregion

    #region Rotação da câmera
    void Update()
    {
        // Obter os movimentos do mouse
        rotaçãoMouse += new Vector2(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * sensibilidadeMouse;

        // Limitar a rotação vertical para evitar problemas de visualização
        rotaçãoMouse.x = Mathf.Clamp(rotaçãoMouse.x, -90f, 90f);

        // Aplicar rotação à câmera
        transform.localRotation = Quaternion.Euler(rotaçãoMouse.x, rotaçãoMouse.y, 0f);
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
