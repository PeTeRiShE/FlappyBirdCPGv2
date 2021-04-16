using UnityEngine;
public class BirdController : MonoBehaviour
{
    
    private const float DoubleClickTime = .25f;
    private float LastClickTime;
    public GameController GameController;
    private Rigidbody2D rb;
    private BombController Bomb;
    [SerializeField] float Velocity = 1f;

    void Start()
    {
        Bomb = GetComponent<BombController>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManagerScript.PlaySound("Wing");   
            rb.velocity = Vector2.up * Velocity;
            float TimeSinceLastClick = Time.time - LastClickTime;
            if (TimeSinceLastClick <= DoubleClickTime)
            {
                BombController.GetInstance.BombsCounter--;
                Debug.Log(TimeSinceLastClick);
            }
            else
            {
                Debug.Log(TimeSinceLastClick);
            }
            LastClickTime = Time.time;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManagerScript.PlaySound("die");
        GameController.GameOver();


    }


}

