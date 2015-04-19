using UnityEngine;
using System.Collections;

public class Avatar : MonoBehaviour
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

    // Use this for initialization
    void Start()
    {
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
    void Update()
    {
        if (_qwutscher != null)
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
