using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RandomAvatarSelector : MonoBehaviour {
    public List<Avatar> Avatar;
    public GameObject Player1Point, Player2Point;
    private List<Avatar> _p1List;
    private List<Avatar> _p2List;
    private Vector2 ImageSize = new Vector2(1, 1);
    private float offset;
	// Use this for initialization
	void Start () {
        _p1List = new List<Avatar>();
        _p2List = new List<Avatar>();

        int count = 0;
        Vector2 yOffset = new Vector2() ;
        foreach (var item in Avatar)
        {
            _p1List.Insert((int)Random.Range(0, _p1List.Count), (Avatar)GameObject.Instantiate(item, new Vector3(0, yOffset.x,-0.1f), Quaternion.identity));
            _p2List.Insert((int)Random.Range(0, _p2List.Count), (Avatar)GameObject.Instantiate(item, new Vector3(20, yOffset.y,-0.1f), Quaternion.identity));
            count++;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private Vector2 GetDimensionInPX(GameObject obj)
    {
        Vector2 tmpDimension;

        tmpDimension.x = obj.transform.localScale.x / obj.GetComponent<SpriteRenderer>().sprite.bounds.size.x;  // this is gonna be our width
        tmpDimension.y = obj.transform.localScale.y / obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y;  // this is gonna be our height

        return tmpDimension;
    }
}
