using UnityEngine;
using System.Collections;

public class TestMoveBehaviourScript : MonoBehaviour
{
	Transform _transform;
	public float Strenght;
	// Use this for initialization
	void Start ()
	{
		_transform = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		var oldPos = _transform.position;
		_transform.position = new Vector3 (oldPos.x /*+ (Input.GetAxis ("Horizontal") * Strenght)*/, oldPos.y + (Input.GetAxis ("Vertical") * Strenght), oldPos.z);
	}
}
 