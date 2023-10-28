using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifetime;

    public float speed;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LifeTimeCheck(lifetime));
    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        else {
            transform.position += -transform.right * Time.deltaTime * speed;
        }
    }

    void Despawn() {
        Destroy(this.gameObject);
    }

    IEnumerator LifeTimeCheck(float time) {

        yield return new WaitForSeconds(time);
        Despawn();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "EnemyCollider") {
            Despawn();
        }
    }

}
