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

	private GameObject Blblblblblbl;

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

		Blblblblblbl = GameObject.Find ("Blblblblblbl");
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
            Debug.Log(Charged+":"+ChargeToPop);
            if (ChargeToPop <= 0)
            {
                Charged = 0;
                QwutscherBubbleBehaviour bubbles = GameObject.FindObjectOfType<QwutscherBubbleBehaviour>();
                           
                if (Charged == -1)
                {
                    _qMeter.ChangeQwutschPoints(50);
                    _qMeter.ChangeQwutschEnergy(10);
                    bubbles.PlayerDislikes(UIQwutscherLikesDislikes.Nothing, Owner == PlayerEnum.Player1);
                }
                else
                    bubbles.PlayerLikes(UIQwutscherLikesDislikes.Nothing, Owner == PlayerEnum.Player1);
            }
            if (Charged == -1)
                ChargeToPop -= Time.deltaTime;
        }
    }


    void OnTriggerEnter(Collider coll)
    {
        var tp = coll.gameObject.GetComponent<Touchpoint>();
        if (tp == null)
            return;
        if (Active)
        {
            if (tp.Owner != this.Owner)
			{
				if(Blblblblblbl != null)
				{
					if(Owner == PlayerEnum.Player1)
						Blblblblblbl.GetComponent<BlScript>().P1.PlayQwutschSound(transform.position);
					else
						Blblblblblbl.GetComponent<BlScript>().P2.PlayQwutschSound(transform.position);
				}
                if (tp.Charged == -1)
                {
                    _qMeter.ChangeQwutschEnergy(-1 * Time.deltaTime);
                    _qMeter.ChangeQwutschPoints(-Energy);
                }
                else
                {
                    _qMeter.ChangeQwutschPoints(Energy);
                    Debug.Log("Points" + Energy);
                    if (tp.ChargeToPop > 0)
                        tp.ChargeToPop -= Energy;
                }
            }
        }
    }

    public void MakeGoodPoint()
    {
        Charged = 1;
        ChargeToPop = 50;
    }

    public void MakeBadPoint()
    {
        Charged = -1;
        ChargeToPop = Random.Range(5, 10);
    }
}