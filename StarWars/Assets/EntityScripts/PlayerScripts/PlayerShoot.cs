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

    public GameObject gunPosition;
    // Update is called once per frame
    private void Start()
    {
        canShoot = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && canShoot) {
            Debug.Log("Start shoot command");
            ShootBullet();
            StartCoroutine(StartCoolDown());
        } else if (Input.GetKeyUp(KeyCode.X) && !canShoot) {
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
