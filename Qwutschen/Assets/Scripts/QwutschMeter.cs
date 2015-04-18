using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class QwutschMeter : MonoBehaviour {
    public float CurrentQwutschPoints;
	public float CurrentQwutschEnergy;
	public float QwutschStartBarLifeTime;
	public float QwutschOverchargeLifeTime;
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
		testOvercharge ();
	}
	
	// Update is called once per frame
	void Update () {

		CurrentQwutschBarLifeTime = _qwutschBar.startLifetime;

	}

	private bool testOvercharge()
	{
		IsOvercharge = _qwutschBar.startLifetime > QwutschOverchargeLifeTime;

		return IsOvercharge;
	}

    public void ChangeQwutschPoints(int amount)
    {
		if (testOvercharge ())
			amount = (int)((float)amount * QwutschOverchargeBonusMultiplicator);
		CurrentQwutschPoints += amount;
    }

	public void ChangeQwutschEnergy(float amount)
	{
		CurrentQwutschPoints += amount;
	}
}
