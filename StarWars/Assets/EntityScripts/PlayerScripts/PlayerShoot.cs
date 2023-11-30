using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UI.Image;
/// <summary>
/// This script handels shooting controls and makes bullet projectlile
/// </summary>
public class PlayerShoot : MonoBehaviour
{

    public float cooldown;

    public bool canShoot;

    public GameObject bulletprefab;

    public AudioSource blastersound;

    public GameObject gunPosition;
    // Update is called once per frame
    private void Start()
    {
        canShoot = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot) {
            Debug.Log("Start shoot command");
            ShootBullet();
            blastersound.Play();
            StartCoroutine(StartCoolDown());
        } else if (Input.GetKeyUp(KeyCode.Mouse0) && !canShoot) {
            Debug.Log("Exit shoot command");
        }
    }

    void ShootBullet() {
        if (transform.localScale.x < 0) {
            var clone = Instantiate(bulletprefab, gunPosition.transform.position, transform.rotation);
            clone.GetComponent<BulletScript>().isRight = false;
        }

        if (transform.localScale.x > 0)
        {
            var clone = Instantiate(bulletprefab, gunPosition.transform.position, transform.rotation);
            clone.GetComponent<BulletScript>().isRight = true;
        }
    }

    IEnumerator StartCoolDown() {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    public float GetRate() {
        return cooldown;
    }

    public void SetRate(float val)
    {
         cooldown = val;
    }
}
