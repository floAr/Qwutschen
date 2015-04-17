using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LogQwutscherLost(Qwutscher qwutscher)
    {
        Debug.LogError("Qwutscher " + qwutscher.Id + " was lost");
    }
}
