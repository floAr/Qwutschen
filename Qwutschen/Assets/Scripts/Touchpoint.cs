using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Touchpoint : MonoBehaviour {
    public enum Player
    {
        Player1,
        Player2
    }

    public Player Owner;
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.GetComponent<Touchpoint>().Owner != this.Owner)
        {
            GameObject.FindObjectOfType<QwutschMeter>().gameObject.SendMessage("Qwutsch", 100);
            Debug.Log("Qwutsch-trigger");
        }
    }
}
