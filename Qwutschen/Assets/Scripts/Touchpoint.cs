using UnityEngine;

public class Touchpoint : MonoBehaviour
{

    public bool Active;
    public float Energy;

    public int Charged;
    public float ChargeToPop;

    private Vector3 _oldPos;

    public float Decay;

    private Transform _transform;

    private QwutschMeter _qMeter;

    public PlayerEnum Owner;


    // Use this for initialization
    void Start()
    {
        _transform = this.GetComponent<Transform>();
        _qMeter = GameObject.FindObjectOfType<QwutschMeter>();
        var sphere = GetComponentsInChildren<MeshRenderer>();
        foreach (var item in sphere)
        {
            item.enabled = false;
        }
    }

    void Update()
    {
        if (Active)
        {
            Energy += Vector3.Magnitude(_transform.position - _oldPos);
            Energy *= Decay;
            _oldPos = _transform.position;
        }
        if (Charged != 0)
        {
            if (ChargeToPop <= 0)
            {
                Charged = 0;
                if (Charged == -1)
                {
                    _qMeter.ChangeQwutschPoints(50);
                    _qMeter.ChangeQwutschEnergy(10);
                }
            }
            if (Charged == -1)
                ChargeToPop -= Time.deltaTime;
        }
    }


    void OnTriggerEnter(Collider coll)
    {
        var tp = coll.gameObject.GetComponent<Touchpoint>();
        if (tp.Owner != this.Owner && Active)

            if (coll.gameObject.GetComponent<Touchpoint>().Owner != this.Owner && Active)
            {
                if (tp.Charged == -1)
                {
                    _qMeter.ChangeQwutschEnergy(-1 * Time.deltaTime);
                    _qMeter.ChangeQwutschPoints(-Energy);
                }
                else
                {
                    _qMeter.ChangeQwutschPoints(Energy);
                    if (ChargeToPop > 0)
                        ChargeToPop -= Energy;
                }
            }
    }

    public void MakeGoodPoint()
    {
        Charged = 1;
        ChargeToPop = 5;
    }

    public void MakeBadPoint()
    {
        Charged = -1;
        ChargeToPop = Random.Range(5, 10);
    }
}