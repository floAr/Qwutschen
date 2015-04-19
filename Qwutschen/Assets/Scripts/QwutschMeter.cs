using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class QwutschMeter : MonoBehaviour {
    public float CurrentQwutschPoints;
	[Range(0f,100f)]
	public float CurrentQwutschEnergy = 100f;
	public float QwutschBarCollYPosMax = 15f;
	[Range(0f,1f)]
	public float QwutschOverchargeCollYPosPercentage = 0.8f;
	public float QwutschBarEnergySubstractionRate = 1f;
	public float QwutschBarOverchargeSubstractionRate = 3f;
	public bool IsOvercharge;
	public bool IsEmpty;
	public float QwutschOverchargeBonusMultiplicator = 2.5f;
	public Transform CollisionPlane;
	public float QwutschTime = 60f;
	public float yPosCollPlane;
	public float TimeElapsed;
	public TextBehaviour PointsText;

	private ParticleSystem _qwutschBar;
	public ParticleSystem Spark;
	// Use this for initialization
	void Start () {
		_qwutschBar = GetComponent<ParticleSystem>();
		testOvercharge ();
	}
	
	// Update is called once per frame
	void Update () {
		yPosCollPlane = Mathf.Lerp (0f, QwutschBarCollYPosMax, CurrentQwutschEnergy / 100f);
		CollisionPlane.localPosition = new Vector3 (CollisionPlane.localPosition.x, yPosCollPlane, CollisionPlane.localPosition.z);

		if (testOvercharge())
			CurrentQwutschEnergy -= QwutschBarOverchargeSubstractionRate * Time.deltaTime;
		else
			CurrentQwutschEnergy -= QwutschBarEnergySubstractionRate * Time.deltaTime;

		TimeElapsed += Time.deltaTime;
		CurrentQwutschEnergy = Mathf.Clamp (CurrentQwutschEnergy, 0f, 100f);
		IsEmpty = CurrentQwutschEnergy <= 0f;

		if (PointsText != null) {
			PointsText.UnwrappedText = string.Format ("{0}", CurrentQwutschPoints.ToString ("0"));
			PointsText.DoLayout = true;
		}
	}

	private bool testOvercharge()
	{
		var currStat = IsOvercharge;
		IsOvercharge = CollisionPlane.localPosition.y > QwutschBarCollYPosMax * QwutschOverchargeCollYPosPercentage;
		if (Spark != null) {
			if (IsOvercharge)
				Spark.enableEmission = true;//.gameObject.SetActive (true);
			else
				Spark.enableEmission = false;//.gameObject.SetActive (false);
		}

		if (currStat != IsOvercharge && IsOvercharge) {
			PlayOverchargeSound();
		}
		return IsOvercharge;
	}

	void PlayOverchargeSound()
	{
		var sound = GetComponent<AudioSource> ();
		if(sound != null) sound.Play ();
	}
	
	public void ChangeQwutschPoints(float amount)
	{
		if (testOvercharge ())
			amount = (amount * QwutschOverchargeBonusMultiplicator);
		CurrentQwutschPoints += amount;
    }

	public void ChangeQwutschEnergy(float amount)
	{
		CurrentQwutschEnergy += amount;
		CurrentQwutschEnergy = Mathf.Clamp (CurrentQwutschEnergy, 0f, 100f);
	}
}
