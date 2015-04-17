using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Qwutscher : MonoBehaviour
{

    public ulong Id;
    public bool IsTracked;
    public Windows.Kinect.Body Body;

    public Vector3 LeftHandPosition;
    public Vector3 LeftElbowPosition;

    public Vector3 RightHandPosition;
    public Vector3 RightElbowPosition;

    public Vector3 HeadPosition;

    public GameObject Tracker;

    public List<GameObject> _tracker;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
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
    }
    public void LogLoss()
    {
        Debug.LogError("Qwutscher " + Id + " was lost");
    }

    private static Vector3 GetVector3FromJoint(Windows.Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}
