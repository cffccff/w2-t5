using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WheelScript : MonoBehaviour
{
	//total Prize in the fortune wheel
	public int totalPrize = 9;
	//Hashset for store unique number for counting all prize have been selected?
	HashSet<int> list = new HashSet<int>();
	//Time take to finish rotation Wheel
	public float rotationTime;
	//Random from 2 number 
	[SerializeField] int rotationNumberFrom;
	[SerializeField] int rotationNumberTo;
	//Times Wheel need to rotate before finish 
	private int rotationNumber;
	//degree of a circle
	private const float wheelCircle = 360f;
	//degree of a Prize in a circle
	private float eachAnglePrize;
	public Transform parent;
	private float currentTime;
	public AnimationCurve curve;
	public AudioSource audioSource;
	public AudioClip clip;
	[SerializeField] int desiredPrize = 1;
	float newAngle;
	public TextMeshPro textMeshPro;
	public SpriteRenderer spriteRenderer;
	private void Start()
	{
		rotationNumberFrom = 1;
		rotationNumberTo = 4;
		eachAnglePrize = wheelCircle / totalPrize;

	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			desiredPrize = 1;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}
	}
	//xoay vòng quay
	IEnumerator SpinWheel()
	{

	
		currentTime = 0;
		if (desiredPrize % 2 == 0)
		{
			Debug.Log("Prize is: " + desiredPrize + " Heart");
		}
		else
		{
			Debug.Log("Prize is: " + desiredPrize + " Coin");
		}
		//calculate the wheel need to rotate degree
		float calculatedAngle = (rotationNumber * wheelCircle) + eachAnglePrize * desiredPrize - eachAnglePrize;
		Debug.Log(calculatedAngle);
		while (currentTime < rotationTime)
		{

			yield return new WaitForEndOfFrame();

			currentTime += Time.deltaTime;
			newAngle = calculatedAngle * curve.Evaluate(currentTime / rotationTime);
			this.transform.eulerAngles = new Vector3(0, 0, newAngle);

		}
		

	}
	
	void SpinImmediately()
	{
		StartCoroutine(SpinWheel());
	
	}
	
	
	
}