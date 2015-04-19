using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class QwutschParticleScript : MonoBehaviour {

	private ParticleSystem _qwutschPS;
	// Use this for initialization
	void Start () {
		_qwutschPS = GetComponent<ParticleSystem> ();
	}

	// Testcode
	float timer = 2f;
	void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0f) {
			EmitAt (Random.insideUnitSphere * 4f);
			timer = Random.Range(0.9f,3f);
		}
	}
	// ------------

	public void EmitAt (Vector3 position)
	{
		_qwutschPS.transform.position = position;
		_qwutschPS.Play ();
	}
}
