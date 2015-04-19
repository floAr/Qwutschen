using UnityEngine;
using System.Collections;

public class ObjectClicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var coll = GetComponent<CircleCollider2D> ();
		if (Input.GetMouseButtonUp (0)) {
			if(coll.OverlapPoint(Input.mousePosition))
			{
				transform.GetChild(0).SendMessage("SelectPart");
			}
		}
	}
}
