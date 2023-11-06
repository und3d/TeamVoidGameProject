﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJoystickRotation : MonoBehaviour
{
	public Joystick joystick;
	public float rotationSpeed = 100f;
	public float moveSpeed = 5f;
	public GameObject Object;
	Vector2 GameobjectRotation;
	private float GameobjectRotation2;
	private float GameobjectRotation3;

	public bool FacingRight = true;

	void Update()
	{
		//Gets the input from the jostick
		GameobjectRotation = new Vector2(joystick.Horizontal, joystick.Vertical);
		Vector3 movement = new Vector3(joystick.Horizontal, joystick.Vertical, 0f).normalized;

		GameobjectRotation3 = GameobjectRotation.x;

		// Moves the object based on the joystick input
        Object.transform.position += movement * moveSpeed * Time.deltaTime;

		// Rotates the object to face the direction of movement
        if (movement != Vector3.zero)
        {
           float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
           float currentAngle = Mathf.SmoothDampAngle(Object.transform.eulerAngles.z, targetAngle, ref rotationSpeed, Time.deltaTime);
           Object.transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        }

		if (FacingRight)
		{
			//Rotates the object if the player is facing right
			GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * 90;
			Object.transform.rotation = Quaternion.Euler(0f, 0f, GameobjectRotation2);
		}
		else
		{
			//Rotates the object if the player is facing left
			GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.y * -90;
			Object.transform.rotation = Quaternion.Euler(0f, 180f, -GameobjectRotation2);
		}
		if (GameobjectRotation3 < 0 && FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}
		else if (GameobjectRotation3 > 0 && !FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}
	}
	private void Flip()
	{
		// Flips the player.
		FacingRight = !FacingRight;

		transform.Rotate(0, 180, 0);
	}


}