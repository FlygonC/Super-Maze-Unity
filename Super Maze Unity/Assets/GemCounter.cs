using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GemCounter : MonoBehaviour {

    private Text textcomp;
    private Image bg;

    private LevelObject level;

	// Use this for initialization
	void Start ()
    {
        bg = GetComponent<Image>();
        textcomp = GetComponentInChildren<Text>();

        Blank();
    }
	
    public void Blank()
    {
        textcomp.text = "";
        bg.color = new Color(1, 1, 1, 0);
    }

	// Update is called once per frame
	void Update ()
    {
	    if (level == null && FindObjectOfType<LevelObject>())
        {
            level = FindObjectOfType<LevelObject>();
        }
        if (level != null)
        {
            if (level.maxGems > 0)
            {
                textcomp.text = level.collectedGems + " / " + level.maxGems;
                bg.color = Color.white;
            }
            else
            {
                Blank();
            }
        }
	}
}
