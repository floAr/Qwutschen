using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Touchpoint : MonoBehaviour {
  

    public PlayerEnum Owner;

    public bool Active;
    public float Energy;

    public bool Charged;
    public float ChargeToPop;

    private Vector3 _oldPos;

    public float Decay;

    private Transform _transform;

    private QwutschMeter _qMeter;

	// Use this for initialization
	void Start () {
        _transform = this.GetComponent<Transform>();
        _qMeter = GameObject.FindObjectOfType<QwutschMeter>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Active)
        {
            Energy += Vector3.Magnitude(_transform.position - _oldPos);
            Energy *= Decay;
            _oldPos = _transform.position;
        }
        if(Charged)
            if (ChargeToPop <= 0)
            {
                Charged = false;
            }
	}

    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.GetComponent<Touchpoint>().Owner != this.Owner && Active)
        {
            GameObject.FindObjectOfType<QwutschMeter>().gameObject.SendMessage("Qwutsch", Energy);
            Energy = 0;
            Debug.Log("Qwutsch-trigger");
        }
    }

    public void MakeGoodPoint()
    {
        Charged = true;
        ChargeToPop = 5;
    }
}
