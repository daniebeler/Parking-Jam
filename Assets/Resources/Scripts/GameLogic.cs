using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody2D rigid;
    public bool canPositiveX = true;
    public bool canNegativeX = true;
    public bool canPositiveY = true;
    public bool canNegativeY = true;
    public bool IsATruck = false;

    private Vector2 MouseDifference;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnMouseDown()
    {
        if (transform.rotation.eulerAngles.z == 90)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }

        isDragging = true;
        MouseDifference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseDifference.x = MouseDifference.x - transform.position.x;
        MouseDifference.y = MouseDifference.y - transform.position.y;
    }

    public void OnMouseUp()
    {
        rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        isDragging = false;
        rigid.velocity = new Vector2(0, 0);
        if (transform.rotation.eulerAngles.z == 90)
        {
            if (IsATruck)
            {
                float Position = transform.position.y - 0.5f;
                Position = Mathf.Round(Position);
                Position = Position + 0.5f;
                transform.position = new Vector2(transform.position.x, Position);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
            }
        }
        else
        {
            if (IsATruck)
            {
                float Position = transform.position.x - 0.5f;
                Position = Mathf.Round(Position);
                Position = Position + 0.5f;
                transform.position = new Vector2(Position, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
            }
        }
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            mousePosition.x = mousePosition.x - MouseDifference.x;
            mousePosition.y = mousePosition.y - MouseDifference.y;
            if (transform.rotation.eulerAngles.z == 90)
            {
                if ((mousePosition.y < 0 && canNegativeY) || (mousePosition.y > 0 && canPositiveY))
                {
                    rigid.velocity = mousePosition * 30;
                }
            }
            else
            {
                if ((mousePosition.x < 0 && canNegativeX) || (mousePosition.x > 0 && canPositiveX))
                {
                    rigid.velocity = mousePosition * 30;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.position.x < transform.position.x && transform.rotation.eulerAngles.z == 0)
        {
            canNegativeX = false;
        }
        else if (coll.transform.position.x > transform.position.x && transform.rotation.eulerAngles.z == 0)
        {
            canPositiveX = false;
        }
        else if (coll.transform.position.y < transform.position.y && transform.rotation.eulerAngles.z == 90)
        {
            canNegativeY = false;
        }
        else if (coll.transform.position.y > transform.position.y && transform.rotation.eulerAngles.z == 90)
        {
            canPositiveY = false;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.position.x < transform.position.x && transform.rotation.eulerAngles.z == 0)
        {
            canNegativeX = true;
        }
        else if (coll.transform.position.x > transform.position.x && transform.rotation.eulerAngles.z == 0)
        {
            canPositiveX = true;
        }
        else if (coll.transform.position.y < transform.position.y && transform.rotation.eulerAngles.z == 90)
        {
            canNegativeY = true;
        }
        else if (coll.transform.position.y > transform.position.y && transform.rotation.eulerAngles.z == 90)
        {
            canPositiveY = true;
        }
    }
}
