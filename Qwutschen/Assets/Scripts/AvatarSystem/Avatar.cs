﻿using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour {

    public Touchpoint Eye;
    public Touchpoint Ear;
    public Touchpoint Nose;
    public Touchpoint Hair;
    public Touchpoint Dress;

    public LipMover UpperFrontLip;
    public LipMover UpperBackLip;
    public LipMover LowerFrontLip;
    public LipMover LowerBackLip;

    private Qwutscher _qwutscher;

	// Use this for initialization
	void Start () {
        _qwutscher = GetComponentInParent<Qwutscher>();
	}
	
	// Update is called once per frame
	void Update () {
        AnimateFace();
	}

    public void AnimateFace()
    {
        UpperBackLip.TargetDistance = _qwutscher.LeftBackOffset;
        UpperFrontLip.TargetDistance = _qwutscher.LeftFrontOffset;
        LowerBackLip.TargetDistance = _qwutscher.RightBackOffset;
        LowerFrontLip.TargetDistance = _qwutscher.RightFrontOffset;

    }
}
