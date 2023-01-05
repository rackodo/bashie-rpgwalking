using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public Vector2 moveDirection;
	public float moveSpeed;
	public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		animator.SetFloat("Horizontal", moveDirection.x);
		animator.SetFloat("Vertical", moveDirection.y);
		animator.SetFloat("Speed", moveDirection.sqrMagnitude);
		rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }

	public void Move(InputAction.CallbackContext context) {
		moveDirection = context.ReadValue<Vector2>();
	}

	public void Fire(InputAction.CallbackContext context) {
		if (SceneManager.GetActiveScene().buildIndex+1 == SceneManager.sceneCountInBuildSettings) {
			SceneManager.LoadScene(0);
		}
		else {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
