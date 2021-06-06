using UnityEngine;

public class Flag : MonoBehaviour
{
    public float speed = 2f;

    private void Start()
    {
        Destroy(gameObject, 15f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        //�������� ������������ �������� � ����������� �� ����������� �������� �����:
        var number = GameController.Instance.Score;
        switch (number)
        {
            case 5:
                speed = 1.6f;
                break;
            case 10:
                speed = 1.9f;
                break;
            case 15:
                speed = 2.3f;
                break;
            case 20:
                speed = 2.9f;
                break;
            case 30:
                speed = 3.8f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
            GameController.Instance.Score++;
        }
        else
        {
            //���� ����������� � ���������� ���� �����, �� ����� ������� ������� � ������� ���������
            RaycastHit2D hit;
            hit = Physics2D.BoxCast(transform.position, transform.localScale*1.5f, 0f, new Vector2(1, 1), .5f);
            if (hit)
            {
                print(hit.collider.name);
                print(gameObject.name);
                hit.transform.position = (hit.transform.position - new Vector3(.5f, 1.5f, 0));
            }
        }
    }
}