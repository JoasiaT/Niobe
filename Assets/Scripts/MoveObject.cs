using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 1.5f;
    public Transform playerTransform;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        GameObject palyerGameObject = GameObject.Find("Player");
        playerTransform = palyerGameObject.transform;
        direction = (playerTransform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime); // - Nie dokonca dziala. Obiekt sam sie porusza. Jak zrobic na kolizje z graczem?
    }
}
