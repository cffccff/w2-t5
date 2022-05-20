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
		rotationTime = 2;
		rotationNumberFrom = 1;
		rotationNumberTo = 4;
		eachAnglePrize = wheelCircle / totalPrize;

	}

	private void Update()
	{
		KeyCodeInput();
	}

	//xoay vòng quay
	IEnumerator SpinWheel()
	{

		ResetAllColorPrize();
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
		audioSource.Stop();

		switch (desiredPrize)
		{

			case 1:
				BlackTextAndSrpite(desiredPrize);
				CountPrizeBlacked(desiredPrize);
				break;
			case 2:
				BlackTextAndSrpite(desiredPrize);
				CountPrizeBlacked(desiredPrize);
				break;
			case 3:
				BlackTextAndSrpite(desiredPrize);
				CountPrizeBlacked(desiredPrize);
				break;
			case 4:
				BlackTextAndSrpite(desiredPrize);
				CountPrizeBlacked(desiredPrize);
				break;
			case 5:
				BlackTextAndSrpite(desiredPrize);
				CountPrizeBlacked(desiredPrize);
				break;
			case 6:
				BlackTextAndSrpite(desiredPrize);
				CountPrizeBlacked(desiredPrize);
				break;
			case 7:
				BlackTextAndSrpite(desiredPrize);
				CountPrizeBlacked(desiredPrize);
				break;
			case 8:
				BlackTextAndSrpite(desiredPrize);
				CountPrizeBlacked(desiredPrize);
				break;
			case 9:
				BlackTextAndSrpite(desiredPrize);
				CountPrizeBlacked(desiredPrize);
				break;

			default:
				break;
		}





	}
	void BlackTextAndSrpite(int i)
	{
		textMeshPro = GameObject.Find("/Fortune Wheel/Data/Gift " + i + "/Text (TMP)").GetComponent<TextMeshPro>();
		spriteRenderer = GameObject.Find("/Fortune Wheel/Data/Gift " + i + "/Sprite").GetComponent<SpriteRenderer>();
		textMeshPro.color = new Color(0, 0, 0, 255);
		spriteRenderer.color = new Color(0, 0, 0, 255);
	}
	void SpinImmediately()
	{
		StartCoroutine(SpinWheel());
		audioSource.PlayOneShot(clip);
	}
	void CountPrizeBlacked(int i)
	{
		list.Add(i);

	}
	void ResetAllColorPrize()
	{
		if (list.Count == 9)
		{
			for (int i = 1; i <= totalPrize; i++)
			{
				textMeshPro = GameObject.Find("/Fortune Wheel/Data/Gift " + i + "/Text (TMP)").GetComponent<TextMeshPro>();
				spriteRenderer = GameObject.Find("/Fortune Wheel/Data/Gift " + i + "/Sprite").GetComponent<SpriteRenderer>();
				textMeshPro.color = new Color(255, 255, 255, 255);
				spriteRenderer.color = new Color(255, 255, 255, 255);
			}
			list.Clear();

		}
	}
	void KeyCodeInput()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			desiredPrize = 1;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			desiredPrize = 2;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			desiredPrize = 3;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			desiredPrize = 4;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			desiredPrize = 5;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}
		if (Input.GetKeyDown(KeyCode.Alpha6))
		{
			desiredPrize = 6;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}
		if (Input.GetKeyDown(KeyCode.Alpha7))
		{
			desiredPrize = 7;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}
		if (Input.GetKeyDown(KeyCode.Alpha8))
		{
			desiredPrize = 8;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}
		if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			desiredPrize = 9;
			rotationNumber = Random.Range(rotationNumberFrom, rotationNumberTo);
			Debug.Log(string.Format("Number Rotation of Wheel: {0}", rotationNumber));
			SpinImmediately();
		}

	}
}