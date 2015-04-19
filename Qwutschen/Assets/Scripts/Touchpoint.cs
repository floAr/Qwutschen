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

                Debug.Log("Qwutsch-trigger");
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