using UnityEngine;
using System.Collections;

public class QwutschSoundScript : MonoBehaviour {
	public AudioClip Male;
	public AudioClip Female;

	private AudioSource _audioSource;

	void Start()
	{
		_audioSource = GetComponent<AudioSource> ();
	}

	public void PlayQwutschSound(Vector3 pos)
	{
		transform.position = pos;
		if (!_audioSource.isPlaying) {
			_audioSource.clip = Random.Range(0,10) < 5 ? Male : Female;
			_audioSource.Play();
		}
	}
}
