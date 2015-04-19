using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    Qwutscher[] _players;
    public GameObject GameGui;
    public GameObject MenuGui;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _players = GameObject.FindObjectsOfType<Qwutscher>();
    }

    // Update is called once per frame
    void Update()
    {
        var gui = GameObject.FindObjectOfType<QwutschMeter>();
        if (gui != null)
        {
            if (gui.IsEmpty)
            {
                GameGui.SetActive(false);
                MenuGui.SetActive(true);
                _players[0].GetRandomAvatar();
                _players[1].GetRandomAvatar();
            }
        }

        if (_players[0].IsTracked && _players[1].IsTracked)
        {
            GameGui.SetActive(true);
            MenuGui.SetActive(false);
        }

    }
}
