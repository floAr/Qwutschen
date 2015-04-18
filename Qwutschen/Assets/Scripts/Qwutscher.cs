using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Qwutscher : MonoBehaviour
{

    public ulong Id;
    public bool IsTracked;
    public Windows.Kinect.Body Body;

    public Vector2 LeftHandPosition;
    public Vector2 LeftElbowPosition;

    public Vector2 RightHandPosition;
    public Vector2 RightElbowPosition;

    public float LeftFrontOffset;
    public float RightFrontOffset;

    public Vector2 HeadPosition;

    public Vector2 AnchorPosition;

    public GameObject Tracker;

    public List<GameObject> _tracker;

    public GameObject Avatar;
    public GameObject LowerLip;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            _tracker.Add(GameObject.Instantiate(Tracker));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Body != null)
        {
            LeftHandPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.HandLeft]);
            LeftElbowPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.ElbowLeft]);
            RightHandPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.HandRight]);
            RightElbowPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.ElbowRight]);
            HeadPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.Head]);
            AnchorPosition = (GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.ShoulderRight]) + GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.ShoulderLeft])) / 2;

            LeftFrontOffset = LeftHandPosition.y - LeftElbowPosition.y;
            RightFrontOffset = RightHandPosition.y - RightElbowPosition.y;

            Avatar.GetComponent<Transform>().position = AnchorPosition;
            LowerLip.GetComponent<SpringJoint2D>().connectedAnchor = RightHandPosition;

            setTracker();
        }
    }

    private void setTracker()
    {
        _tracker[0].GetComponent<Transform>().position = LeftHandPosition;
        _tracker[1].GetComponent<Transform>().position = LeftElbowPosition;
        _tracker[2].GetComponent<Transform>().position = RightHandPosition;
        _tracker[3].GetComponent<Transform>().position = RightElbowPosition;
        _tracker[4].GetComponent<Transform>().position = HeadPosition;
        _tracker[5].GetComponent<Transform>().position = AnchorPosition;
    }
    public void LogLoss()
    {
        Debug.LogError("Qwutscher " + Id + " was lost");
    }

    private static Vector3 GetVector3FromJoint(Windows.Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 6, joint.Position.Y * 6, 0);
    }

    public void AnimateFace()
    {

    }
}
