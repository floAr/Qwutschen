using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class QwutschMeter : MonoBehaviour {
    public float CurrentQwutschPoints;
	[Range(0f,100f)]
	public float CurrentQwutschEnergy;
	public float QwutschStartBarLifeTime = 15f;
	public float QwutschOverchargeLifeTime;
	[Range(0f,1f)]
	public float QwutschOverchargeLifeTimePercentage = 0.8f;
	public float CurrentQwutschBarLifeTime;
	public float QwutschBarEnergySubstractionRate;
	public float QwutschBarOverchargeSubstractionRate;
	public bool IsOvercharge;
	public float QwutschOverchargeBonusMultiplicator;
	private ParticleSystem _qwutschBar;
	// Use this for initialization
	void Start () {
		_qwutschBar = GetComponent<ParticleSystem>();
		_qwutschBar.startLifetime = QwutschStartBarLifeTime;
		QwutschOverchargeLifeTime = QwutschStartBarLifeTime * QwutschOverchargeLifeTimePercentage;
		testOvercharge ();
	}
	
	// Update is called once per frame
	void Update () {
		_qwutschBar.startLifetime = Mathf.Lerp (0f, 15f, CurrentQwutschEnergy / 100f);
		//_qwutschBar.pa
		CurrentQwutschBarLifeTime = _qwutschBar.startLifetime;

	}

	private bool testOvercharge()
	{
		IsOvercharge = _qwutschBar.startLifetime > QwutschOverchargeLifeTime;

		return IsOvercharge;
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
