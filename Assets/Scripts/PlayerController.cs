using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

	//Speed of the Player
	public float speed = 10.0F;

	//bounds of player
	public float leftBound = -5F;
	public float rightBound = 5F;
	public float upBound = 3.5F;
	public float downBound = -3.5F;

	public bool alive;
	// Use this for initialization
	void Start () {
		alive = true;
	}

	private Vector3 moveVec;
	float movementSpeedX = 0;
	private float movementSpeedY = 0;
	public void OnMove(InputValue input)
	{
		Debug.Log("OnMove");
		Vector2 inputVec = input.Get<Vector2>();
		moveVec = new Vector3(inputVec.x, 0, inputVec.y);
		Debug.Log(moveVec.x);


		float horizontalMovement = inputVec.x;
		float verticalMovement = inputVec.y;

		movementSpeedX = Time.deltaTime * horizontalMovement * speed;		//Horizontal Speed
		movementSpeedY = Time.deltaTime * verticalMovement * speed;			//Vertical Speed

		
	}

	
	public void OnJump()
	{
		Debug.Log("Jump!");
	}

	// Update is called once per frame
	void Update () {
		Transform t = transform;
		t.Translate(movementSpeedX, movementSpeedY, 0);							//Player Movement

		//creates bounds around player
		if(t.position.x > rightBound){
			t.position = new Vector3(rightBound,t.position.y,0);
		} else if(transform.position.x < leftBound){
			t.position = new Vector3(leftBound,t.position.y,0);
		}

		if(transform.position.y > upBound){
			t.position = new Vector3(t.position.x,upBound,0);
		} else if(transform.position.y < downBound){
			t.position = new Vector3(t.position.x,downBound,0);
		}
		

	}
}
