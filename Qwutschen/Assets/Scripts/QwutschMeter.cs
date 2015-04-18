using UnityEngine;
using System.Collections;

public class QwutschMeter : MonoBehaviour {
    public float CurrentQwutsch;
    public float CurrentLevel;
    public float NextLevelQwutsch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(CurrentQwutsch>=NextLevelQwutsch)
    {
        CurrentQwutsch -= NextLevelQwutsch;
        NextLevelQwutsch = NextLevelQwutsch * 2.6f;
        CurrentLevel++;
    }
	}

    public void Qwutsch(int points)
    {

        CurrentQwutsch += points;
    }
}
