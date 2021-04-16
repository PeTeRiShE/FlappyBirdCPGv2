using UnityEngine;
using UnityEngine.UI;

public class BombController : MonoBehaviour
{

    private const int BombLimit = 3;
    private static BombController Instance;
    public static BombController GetInstance
    {
        get
        {
            return Instance;
        }
    }

    
    public Image[] bombs;
    private int bombsCounter;
    public int BombsCounter
    {
        get
        {
            return bombsCounter;
        }
        set
        {
            if (value > bombsCounter)
            {
                if (bombsCounter < BombLimit)
                {
                    bombsCounter = value;
                    OnBombAdded();
                }
            }
            else
            {
                if (bombsCounter > 0)
                {
                    bombsCounter = value;
                    OnBombRemoved();
                }
            }
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        bombs = GetComponentsInChildren<Image>();
        foreach (Image bomb in bombs)
        {
            if (bomb.GetComponent<BombController>() == null)
            {
                bomb.gameObject.SetActive(false);
            }
        }
    }

  

    public void OnBombAdded()
    {
        foreach (Image image in bombs)
        {
            if (bombsCounter * 90 + (-180) == image.transform.localPosition.x)
            {
                image.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void OnBombRemoved()
    {
        foreach (Image image in bombs)
        {
            if (bombsCounter * 90 + (-90) == image.transform.localPosition.x)
            {
                image.gameObject.SetActive(false);
                ObjectPool.GetInstance.HidePipes();
                SoundManagerScript.PlaySound("Bomb");
                break;
            }
        }
    }
}
