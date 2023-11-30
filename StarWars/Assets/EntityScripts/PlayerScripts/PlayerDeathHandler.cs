using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    public int playerLives;

    public GameObject playerSpawner;

    public EntityHealthHandler healthHandler;

    public SpriteRenderer spriterender;

    public Rigidbody2D rigidbody;

    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        playerLives = 0;
        isDead = false;
        playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ExecuteDeath());
    }

    IEnumerator ExecuteDeath() {
        if (healthHandler.GetHealth() < -1 && !isDead)
        {

            if (playerLives - 1 < 0) {
                GameManager.Instance.GameOver();
            }

            playerLives = playerLives - 1;
            rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            spriterender.enabled = false;
            isDead = true;
            yield return new WaitForSeconds(1f);
            transform.position = playerSpawner.transform.position;
            yield return new WaitForSeconds(1f);
            if (playerLives >= 0) {
                rigidbody.constraints = RigidbodyConstraints2D.None;
                spriterender.enabled = true;
                healthHandler.SetHealth(100);
                isDead = false;
            }
        }
    }

    public int GetLife() {
        return playerLives;
    }

    public void SetLife(int val)
    {
        playerLives = val;
    }
}
