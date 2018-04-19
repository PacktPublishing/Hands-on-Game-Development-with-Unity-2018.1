using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControls : MonoBehaviour
{
    /// <summary>
    /// The actor is the game object in the world
    /// representing this character/entity.
    /// </summary>
    [SerializeField] private GameObject actor;
    private Vector3 mousePosition;
    private Vector3 lookDirection;
    
    public void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        Quaternion lookRotation = GetMouseInput();
        actor.transform.rotation = lookRotation;
        
        Vector3 moveDirection = GetInput();
        //Vector3 lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //actor.transform.position += moveDirection * Time.deltaTime;
        actor.transform.Translate(moveDirection * Time.deltaTime, Space.World);
    }

    private Vector3 GetInput()
    {
        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        return input;
    }

    private Quaternion GetMouseInput()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 relativeMousePos = new Vector2(mousePos.x - Screen.width/2, mousePos.y - Screen.height/2);
        float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg * -1;
        //Debug.Log(String.Format("mouse pos: {0} | center: {1} | angle: {2} ", mousePos, 0.ToString(), angle));
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
        return rot;
    }
}
