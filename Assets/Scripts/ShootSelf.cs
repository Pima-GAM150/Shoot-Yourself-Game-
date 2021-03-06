﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootSelf : MonoBehaviour
{

    public GameObject player;
    public GameObject shotPlayer;
    public int speed;
    public bool isInstanciated;
    public float coolDownTime;
    private float nextFiretime;
    public List<GameObject> players;



    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        shoot();

        if (!isInstanciated)
        {
            StartCoroutine(waitForInstanciate());
            StopAllCoroutines();

            isInstanciated = true;
        }

        fire();
    }




    public bool shoot()
    {

        bool bulletCreated = false;
        Vector2 playerPos = player.transform.position;
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
        Quaternion q = Quaternion.FromToRotation(Vector2.up, screenPos - playerPos);
        if (Input.GetMouseButtonDown(0))
        {
            if (transform.localScale.x < 0 && bulletCreated == false && nextFiretime < Time.time)
            {
                nextFiretime = Time.time + coolDownTime;
                player = Instantiate(shotPlayer, new Vector2(playerPos.x, playerPos.y), q);
                players.Add(player);
                if (isInstanciated) {
                    foreach (GameObject player in players) {
                        this.enabled = false;


                    }
                }
            }
            else if (nextFiretime < Time.time)
            {
                nextFiretime = Time.time + coolDownTime;
                player = Instantiate(shotPlayer, new Vector2(playerPos.x, playerPos.y), q);
                players.Add(player);
                if (isInstanciated)
                {
                    foreach (GameObject player in players)
                    {
                        //if (!this.gameObject.CompareTag("StartCannon"))
                            this.enabled = false;
                     

                    }
                }
            }
            bulletCreated = true;
        }
        return bulletCreated;
    }






    public void fire()
    {
        GetComponent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().transform.up * speed);
    }

    IEnumerator waitForInstanciate()
    {

        yield return new WaitUntil(() => shoot());

    }

}
