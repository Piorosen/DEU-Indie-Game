using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int power;
    public bool enemy;
    public int knockbackDistance = 500;
    public int swingSpeed = 500;
    public int swingAngle = 100;

    private int dx, dy;
    private float offX, offY;

    private bool swinging;
    private float swingStep;
    private const int maxSwingStep = 100;
	
	void Update ()
    {
        var hide = dx == 0 && dy == 0 || !swinging;
        GetComponent<Collider2D>().enabled = !hide;
        GetComponent<SpriteRenderer>().enabled = !hide;

        if(swinging) {
            swingStep += Time.deltaTime * swingSpeed;
            float angle = -swingStep / maxSwingStep * swingAngle;
            angle += Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
            angle += (180 - swingAngle) / 2;
            transform.eulerAngles = new Vector3(0, 0, angle);
            if(swingStep >= maxSwingStep) {
                swingStep = 0;
                swinging = false;
            }
            var weaponPosition = new Vector3(offX, offY, 0);
            this.transform.localPosition = weaponPosition;
        }
	}

    public void Swing(int dx, int dy)
    {
        if(!swinging)
        {
            this.dx = dx;
            this.dy = dy;

            swinging = true;
            swingStep = 0;
            offX = dx * 0.4f;
            offY = dy * 0.1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.collider.gameObject;
        if(!enemy && other.tag == "Enemy" || enemy && other.tag == "Player")
        {
            var character = other.GetComponent<Character>();
            character.Damage(power);
            var dir = other.transform.position - this.transform.position;
            dir = other.transform.InverseTransformDirection(dir);
            var angle = Mathf.Atan2(dir.y, dir.x);
            character.Knockback(angle, 500);
        }
    }

}
