using UnityEngine;
using System.Collections;

public class LipMover : MonoBehaviour
{

    public float Speed;
    public float Length;
    public float TargetDistance;

    private float _currentDistance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _currentDistance += (TargetDistance - _currentDistance) * Speed * Time.deltaTime;
        var alpha = Mathf.Asin(_currentDistance * 0.8939966636f / Length) * 57.2957795;
        Debug.Log(alpha);
        if (!(double.IsNaN(alpha)))
            this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, (float)alpha);

    }
}
