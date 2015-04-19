using UnityEngine;
using System.Collections;
using System;

public class Avatar:MonoBehaviour
{

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

    private float _nextGood, _nextBad;

	// Use this for initialization
    void Start()
    {

        _nextBad = 15;
        _nextGood = 10;
        _qwutscher = GetComponentInParent<Qwutscher>();
        foreach (Transform t in transform)
        {
            if (t.name.ToLower() == "mouth")
            {
                var tp = t.GetComponentsInChildren<LipMover>();
                foreach (var item in tp)
                {
                    if (item.name.ToLower().Contains("upper"))
                    {
                        if (item.name.ToLower().Contains("front"))
                        {
                            UpperFrontLip = item;
                        }
                        else
                        {
                            UpperBackLip = item;
                        }
                    }
                    else
                    {
                        if (item.name.ToLower().Contains("front"))
                        {
                            LowerFrontLip = item;
                        }
                        else
                        {
                            LowerBackLip = item;
                        }
                    }
                }
            }
        }
    }
	
	
	// Update is called once per frame
	void Update () {
        if (_qwutscher != null)
            AnimateFace();
        _nextGood-=Time.deltaTime;
        _nextBad-=Time.deltaTime;
        if(_nextGood<=0)
        {
            UIQwutscherLikesDislikes like = (UIQwutscherLikesDislikes)UnityEngine.Random.Range(0, Enum.GetValues(typeof(UIQwutscherLikesDislikes)).Length);
            QwutscherBubbleBehaviour bubbles = GameObject.FindObjectOfType<QwutscherBubbleBehaviour>();
            bubbles.PlayerLikes(like, _qwutscher.Player == PlayerEnum.Player1);
            switch (like)
            {
                case UIQwutscherLikesDislikes.Nose:
                    Nose.MakeGoodPoint();
                    break;
                case UIQwutscherLikesDislikes.Eye:
                    Eye.MakeGoodPoint();
                    break;
                case UIQwutscherLikesDislikes.Ear:
                    Ear.MakeGoodPoint();
                    break;
                default:
                    break;
            }
            _nextGood = UnityEngine.Random.Range(5, 15);
        }
        if(_nextBad<=0)
        {
            UIQwutscherLikesDislikes dislike = (UIQwutscherLikesDislikes)UnityEngine.Random.Range(0, Enum.GetValues(typeof(UIQwutscherLikesDislikes)).Length);
            QwutscherBubbleBehaviour bubbles = GameObject.FindObjectOfType<QwutscherBubbleBehaviour>();
            bubbles.PlayerDislikes(dislike, _qwutscher.Player == PlayerEnum.Player1);
            switch (dislike)
            {
                case UIQwutscherLikesDislikes.Nose:
                    Nose.MakeBadPoint();
                    break;
                case UIQwutscherLikesDislikes.Eye:
                    Eye.MakeBadPoint();
                    break;
                case UIQwutscherLikesDislikes.Ear:
                    Ear.MakeBadPoint();
                    break;
                default:
                    break;
            }
            _nextBad = UnityEngine.Random.Range(10, 15);
        }
	}

    public void AnimateFace()
    {
        UpperBackLip.TargetDistance = _qwutscher.LeftBackOffset;
        UpperFrontLip.TargetDistance = _qwutscher.LeftFrontOffset;
        LowerBackLip.TargetDistance = _qwutscher.RightBackOffset;
        LowerFrontLip.TargetDistance = _qwutscher.RightFrontOffset;

    }
}
