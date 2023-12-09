using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerStats
{
    private Camera mainCamera;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        //movement
        Vector2 moveVect = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        Move(moveVect.normalized);

        //player to mouse screen rotation
        Vector3 PlayerScreenPos = mainCamera.WorldToScreenPoint(transform.position);
        Vector3 MouseScreenPos = Input.mousePosition;
        Vector2 screenRot = new Vector2(MouseScreenPos.x - PlayerScreenPos.x, MouseScreenPos.y - PlayerScreenPos.y);
        screenRot = new Vector2(screenRot.x / mainCamera.pixelWidth, screenRot.y / mainCamera.pixelHeight);
        screenRot.Normalize();
        facingDir = screenRot;
    }

}
