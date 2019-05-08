using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody2D bulletPrefab;
    public float attackSpeed = 1.0f;
    public float coolDown;
    public float yValue = 1f; // Used to make it look like it's shot from the gun itself (offset)
    public float xValue = 0.2f;
    public bool isFired = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (1 > coolDown)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
               
            }
        }

    }
    void Fire()
    {
        //Rigidbody2D bPrefab = Instantiate(bulletPrefab,transform.position,Quaternion.identity) as Rigidbody2D;

        Rigidbody2D bPrefab = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        bulletPrefab.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

        
    }
}
