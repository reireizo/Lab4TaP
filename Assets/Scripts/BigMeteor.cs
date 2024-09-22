using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class BigMeteor : Meteor
{
    private int hitCount = 0;
    public ParticleSystem bigExplode;
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
            ExplodeEffect();
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

    public override void ExplodeEffect()
    {
        GameManager.soundEffect.PlayOneShot(breakSound);
        var ex = Instantiate(bigExplode, this.transform.position, Quaternion.identity);
        Destroy(ex.gameObject, 2f);
    }
}
