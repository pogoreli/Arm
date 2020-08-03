using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;


public class RoboticArm : Agent
{
	//this are the parts of the robotic arm
	public Transform part0;
	public Transform part1;
	public Transform part2;
	public Transform part3;
	public Transform gripLeft;
	public Transform gripRight;

	//variables
	public float rotationSpeed = 1f;
	private float radius;
	public Vector3 center;

	//Sciene elements
	public GameObject cube;
	public GameObject basket;
	public GameObject arm;
	public GameObject PlaceHolder;

	//Defines the direction of rotation of an element, which is moving at this time
	private float direction = 0f;

	public override void Initialize()
	{
		
	}

	void Start ()
	{

	}

    public override void OnEpisodeBegin()
    {
		resetBasket();
		resetCube();
		resetArm();
    }

    //public override void CollectObservations(VectorSensor sensor)
    //{
    //    sensor.AddObservation(part0.transform.rotation);
    //    sensor.AddObservation(part1.transform.rotation);
    //    sensor.AddObservation(part2.transform.rotation);
    //    sensor.AddObservation(part3.transform.rotation);
    //    sensor.AddObservation(gripLeft.transform.rotation);
    //    sensor.AddObservation(gripRight.transform.rotation);
    //    sensor.AddObservation(arm.transform.position);

    //    sensor.AddObservation(basket.transform.position);
    //    sensor.AddObservation(cube.transform.position);
    //    sensor.AddObservation(PlaceHolder.transform.position);
    //    sensor.AddObservation(cube.transform.rotation);
    //    sensor.AddObservation(PlaceHolder.transform.rotation);
    //}

    // Update is called once per frame

    void Update() //replace by onActionReceived
	{
		center = arm.transform.position;


		if (Input.GetKey(KeyCode.Keypad9))
		{
			OnEpisodeBegin();
		}

		part0r();
		part1r();
		part2r();
		part3r();
		Gripsr();
	}

	public void part0r()
    {
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			direction = -rotationSpeed;
			rotatePart0(direction);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			direction = rotationSpeed;
			rotatePart0(direction);
		}
		direction = 0f;
	}

	public void part1r()
    {
		if (Input.GetKey(KeyCode.UpArrow))
		{
			direction = rotationSpeed;
			rotatePart1(direction);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			direction = -rotationSpeed;
			rotatePart1(direction);
		}
		direction = 0f;
	}

	public void part2r()
	{
		if (Input.GetKey(KeyCode.Keypad8))
		{
			direction = rotationSpeed;
			rotatePart2(direction);
		}
		else if (Input.GetKey(KeyCode.Keypad2))
		{
			direction = -rotationSpeed;
			rotatePart2(direction);
		}
		direction = 0f;
	}

	public void part3r()
	{
		if (Input.GetKey(KeyCode.Keypad7))
		{
			direction = -rotationSpeed;
			rotatePart3(direction);
		}
		else if (Input.GetKey(KeyCode.Keypad1))
		{
			direction = rotationSpeed;
			rotatePart3(direction);
		}
		direction = 0f;
	}

	public void Gripsr()
	{
		if (Input.GetKey(KeyCode.Keypad4))
		{
			direction = -rotationSpeed;
			grip(direction);
		}
		else if (Input.GetKey(KeyCode.Keypad6))
		{
			direction = rotationSpeed;
			grip(direction);
		}
		direction = 0f;
	}

	public void rotatePart0(float val)
	{
		part0.transform.Rotate(Vector3.forward, val);
		direction = 0f;
	}

	public void rotatePart1(float val)
	{
		part1.transform.Rotate(Vector3.forward, val);
		direction = 0f;
	}

	public void rotatePart2(float val)
	{
		part2.transform.Rotate(Vector3.forward, val);
		direction = 0f;
	}

	public void rotatePart3(float val)
	{
		part3.transform.Rotate(Vector3.right, val);
		direction = 0f;
	}


	public void grip(float val)
	{
		gripLeft.transform.Rotate(Vector3.forward, val);
		gripRight.transform.Rotate(Vector3.forward, val);
		direction = 0f;
	}



	//Reseting the sciene
	public void resetBasket()
	{
		basket.transform.position = ChooseRandomPosition(3f, 5f) + Vector3.up * 20f;
	}

	public void resetCube()
	{
		cube.transform.position = ChooseRandomPosition(1.5f, 3f) + Vector3.up * 20f;
	}

	public void resetArm()
	{
		this.transform.position = center;
	}

	//Generating the random location around the arm
	public Vector3 ChooseRandomPosition(float min, float max) //static
	{
		radius = UnityEngine.Random.Range(min, max);
		return center + Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f) * Vector3.forward * 3;
	}
}
