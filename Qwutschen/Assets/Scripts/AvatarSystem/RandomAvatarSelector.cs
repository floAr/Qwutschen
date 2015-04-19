using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RandomAvatarSelector : MonoBehaviour {
    public List<Avatar> Avatars;
	// Use this for initialization

    public Avatar GetRandomAvatar()
    {
        return Avatars[Random.Range(0, Avatars.Count)];
    }
}
