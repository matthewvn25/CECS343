using UnityEngine;

public class playerMove : MonoBehaviour
{

    public Vector2 speed = new Vector2(10, 10);
    private bool isandroid;
    private Vector2 movement;
    private float inputX;
    private float inputY;
    public GameObject enemyGen;
    void Start()
    {
        //gameObject.SetActive(true);
#if UNITY_ANDROID
		isandroid = true;
#endif
#if !UNITY_ANDROID
        isandroid = false;
#endif
    }

    void Update()
    {
        //gameObject.SetActive(true); //needed so that menu and restart can be looped

        if (isandroid == false)
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
        }
        else
        {
            inputX = Input.acceleration.x;
            inputY = Input.acceleration.y;
        }

        movement = new Vector2(
            speed.x * inputX,
            speed.y * inputY);

        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0.1f, 0, dist)
            ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0.9f, 0, dist)
            ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)
            ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)
            ).y;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
            transform.position.z
            );

        if(gameTimer.getGameEnded())
        {
            gameObject.SetActive(false);
        }

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }

}