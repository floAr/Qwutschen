using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class BodyPartSelection : MonoBehaviour {

	private SpriteRenderer _spriteRenderer;
	// Use this for initialization
	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		_spriteRenderer.enabled = false;
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

	public void SelectPart ()
	{
		_spriteRenderer.enabled = true;
	}
}
