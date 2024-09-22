using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class BigMeteor : Meteor
{
    private int hitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.5f);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }

        if (hitCount >= 5)
        {
            OnMeteorDestroyed.Invoke();
            GameObject.Find("GameManager").GetComponent<GameManager>().bigMeteorCount--;
            GameManager.soundEffect.PlayOneShot(breakSound);
            Destroy(this.gameObject);
        }
    }

    public override void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            whatIHit.gameObject.SetActive(false);
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }
}
