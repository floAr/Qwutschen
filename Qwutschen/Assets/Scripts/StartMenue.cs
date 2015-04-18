using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rotator : MonoBehaviour {

   public GameObject Background;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Background.GetComponent<Transform>().Rotate(0, 0, 1);
	}
}
