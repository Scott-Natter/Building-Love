using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeControl : MonoBehaviour
{
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 500;
    }

    public void damage(int value) {
        hp -= value;
        if (hp <= 0)
        {
            GameObject.Find("Boy").GetComponent<PlayerControl>().nub_wood++;
            GameObject.Find("Boy").GetComponent<PlayerControl>().nub_wood++;

            Destroy(this.gameObject);
        }
    }
}
