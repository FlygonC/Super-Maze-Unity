using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum LevelState : int { PreLevel, PlayLevel, PostLevel };

public class PlayManager : MonoBehaviour {

    [SerializeField]
    private Worlds CurrentWorld = Worlds.TrapFactory;
    [SerializeField]
    private int CurrentLevel = 0;
    [SerializeField]
    private LevelState levelState = LevelState.PreLevel;
    [SerializeField]
    private Timer levelTime;
    [SerializeField]
    private PlayerControl playerPrefab;
    private LevelObject CurrentLevelObject
    {
        get
        {
            return Globals.GetLevel(CurrentWorld, CurrentLevel);
        }
    }
    [SerializeField]
    private Image preLevelUI;
    [SerializeField]
    private Image PlayLevelUI;
    [SerializeField]
    private Image PostLevelUI;
    [SerializeField]
    private Text levelTitleText;

    [SerializeField]
    private GameObject BackgroundObject;

    private int playerHasDiedTimer = 60 * 3;

    void Start()
    {
        ResetLevel();
    }

    void Update ()
    {
        switch (levelState)
        {
            case LevelState.PreLevel:

                if (Input.GetButtonDown("Activate"))
                {
                    StartLevel();
                }

                break;

            case LevelState.PlayLevel:
                
                if (!FindObjectOfType<PlayerControl>())
                {
                    playerHasDiedTimer--;
                    if (playerHasDiedTimer <= 0)
                    {
                        ResetLevel();
                    }
                }

                break;
            case LevelState.PostLevel:

                if (Input.GetButtonDown("Activate"))
                {
                    NextLevel();
                    ResetLevel();
                }
                if (Input.GetButtonDown("Pickup"))
                {
                    ResetLevel();
                }

                break;

            default:
                break;
        }
	}

    [ContextMenu("Restart")]
    public void ResetLevel()
    {
        UpdateBackground();
        foreach (LevelObject i in FindObjectsOfType<LevelObject>())
        {
            Destroy(i.gameObject);
        }
        foreach (Actor i in FindObjectsOfType<Actor>())
        {
            Destroy(i.gameObject);
        }
        levelState = LevelState.PreLevel;

        levelTitleText.text = CurrentLevelObject.name;

        preLevelUI.gameObject.SetActive(true);
        PlayLevelUI.gameObject.SetActive(false);
        PostLevelUI.gameObject.SetActive(false);
    }
    [ContextMenu("Play")]
    public void StartLevel()
    {
        if (levelState == LevelState.PreLevel)
        {
            PlayerControl buildPlayer = Instantiate(playerPrefab);
            LevelObject buildLevel = Instantiate(CurrentLevelObject);
            
            playerHasDiedTimer = 60 * 3;

            levelState = LevelState.PlayLevel;

            preLevelUI.gameObject.SetActive(false);
            PlayLevelUI.gameObject.SetActive(true);
            PostLevelUI.gameObject.SetActive(false);
        }
    }
    [ContextMenu("Finish")]
    public void FinishLevel()
    {
        if (levelState == LevelState.PlayLevel)
        {
            foreach (Actor i in FindObjectsOfType<Actor>())
            {
                Destroy(i.gameObject);
            }

            // Save level stats
            levelState = LevelState.PostLevel;

            preLevelUI.gameObject.SetActive(false);
            PlayLevelUI.gameObject.SetActive(false);
            PostLevelUI.gameObject.SetActive(true);
        }
    }

    private void NextLevel()
    {
        CurrentLevel++;
        if (CurrentLevel >= 5)
        {
            CurrentLevel = 0;
            switch (CurrentWorld)
            {
                default:
                case Worlds.TrapFactory:
                    CurrentWorld = Worlds.CloudySky;
                    break;
                case Worlds.CloudySky:
                    CurrentWorld = Worlds.SpookyHouse;
                    break;
                case Worlds.SpookyHouse:
                    CurrentWorld = Worlds.PuzzleTower;
                    break;
            }
        }
    }

    private void UpdateBackground()
    {
        switch (CurrentWorld)
        {
            default:
            case Worlds.TrapFactory:
                BackgroundObject.GetComponent<SpriteRenderer>().sprite = Globals.globals.TrapFactoryBG;
                break;
            case Worlds.CloudySky:
                BackgroundObject.GetComponent<SpriteRenderer>().sprite = Globals.globals.CloudySkyBG;
                break;
            case Worlds.SpookyHouse:
                BackgroundObject.GetComponent<SpriteRenderer>().sprite = Globals.globals.SpookyBG;
                break;
        }
    }
}
