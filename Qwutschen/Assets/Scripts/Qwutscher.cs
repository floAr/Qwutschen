using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Qwutscher : MonoBehaviour
{

    public ulong Id;
    public bool IsTracked;
    public Windows.Kinect.Body Body;

    private Vector2 LeftHandPosition;
    private Vector2 LeftElbowPosition;
    private Vector2 RightHandPosition;
    private Vector2 RightElbowPosition;
    private Vector2 LeftShoulderPosition;
    private Vector2 RightShoulderPosition;
    private Vector2 HeadPosition;

    public float LeftFrontOffset;
    public float RightFrontOffset;

    public float LeftBackOffset;
    public float RightBackOffset;

    public Vector2 AnchorPosition;

    public GameObject Tracker;

    public List<GameObject> _tracker;

    public Avatar Avatar;

    public PlayerEnum Player;

    private bool _lastTracked;

    public bool KinectInput = true;

    private Transform _transform;
    private Renderer _renderer;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            _tracker.Add(GameObject.Instantiate(Tracker));
        }
        _transform = this.GetComponent<Transform>();
        _renderer = this.GetComponent<Renderer>();
        _lastTracked = !IsTracked;

        foreach (var item in GetComponentsInChildren<Touchpoint>())   
        {
            item.Owner = Player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_lastTracked != IsTracked)
        {
            _lastTracked = IsTracked;
            SetRenderer();
        }
        if (KinectInput)
        {
            if (Body != null)
            {
                LeftHandPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.HandLeft]);
                LeftElbowPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.ElbowLeft]);
                RightHandPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.HandRight]);
                RightElbowPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.ElbowRight]);
                HeadPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.Head]);
                LeftShoulderPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.ShoulderLeft]);
                RightShoulderPosition = GetVector3FromJoint(Body.Joints[Windows.Kinect.JointType.ShoulderRight]);
                AnchorPosition = (RightShoulderPosition + LeftShoulderPosition) / 2;

                LeftFrontOffset = LeftHandPosition.y - AnchorPosition.y;
                RightFrontOffset = RightHandPosition.y - AnchorPosition.y;
                LeftBackOffset = LeftElbowPosition.y - AnchorPosition.y;
                RightBackOffset = RightElbowPosition.y - AnchorPosition.y;

            }
        }
        else
        {
            LeftFrontOffset = Input.GetAxis("LeftFrontAxis") * 1.8f;
            RightFrontOffset = Input.GetAxis("RightFrontAxis") * 1.8f;
            LeftBackOffset = Input.GetAxis("LeftBackAxis") * 1.8f;
            RightBackOffset = Input.GetAxis("RightBackAxis") * 1.8f;
        }


        Avatar.GetComponent<Transform>().position = AnchorPosition;

        setTracker();
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



    private void SetRenderer()
    {
        var renderers = this.GetComponentsInChildren<Renderer>();
        foreach (var item in renderers)
        {
            item.enabled = IsTracked;
        }
    }
}
