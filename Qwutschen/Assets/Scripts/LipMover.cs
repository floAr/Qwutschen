using UnityEngine;
using System.Collections;

public class LipMover : MonoBehaviour
{

    public float Speed;
    public float Length;
    public float TargetDistance;
    public float Dampening = 2;

    private float _currentDistance;

    private Transform _transform;
    // Use this for initialization
    void Start()
    {
        _transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _currentDistance += (TargetDistance - _currentDistance) * Speed * Time.deltaTime;
        var alpha = Mathf.Asin(_currentDistance * 0.8939966636f / Length) * 57.2957795 / Dampening;
        if (!(double.IsNaN(alpha)))
            _transform.localRotation = Quaternion.Euler(0, 0, (float)alpha);


    }
}
