using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthMeterScript : MonoBehaviour {

    [SerializeField]
    private Sprite[] images;
    [SerializeField]
    private PlayerControl player;
    private Image render;


	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerControl>();
        render = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!player)
        {
            player = FindObjectOfType<PlayerControl>();
        }
        if (player)
        {
            //player = FindObjectOfType<PlayerControl>();

            render.sprite = images[player.life];
        }
        else
        {
            render.sprite = images[0];
        }
	}
}
