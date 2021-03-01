using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 pos_ori;
    public bool isRun;
    public bool isStart;
    public bool isGround;
    public float speed;
    public int nub_wood;
    public int damage_value;
    public Text text_wood;
    public Text text_cut; 
    public Text text_end;
    public Animator animator;
    public TreeControl tree;
    public GameObject bridge;
    public float time_Sea;
    public float time_Sea_Current;


    void Start()
    {
        time_Sea = 1.0f;
        time_Sea_Current = 1.0f;
        pos_ori = transform.position;
        damage_value = 3;
        tree = null;
        speed = 5.0f;
        isRun = false;
        isStart = true;
        isGround = false;
        nub_wood = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        text_wood.text = "Wood: " + nub_wood;
        if (isStart)
        {
            if (isGround)
                Movement();
            else {
                if (time_Sea_Current < 0.0f)
                {
                    isStart = false;
                    text_end.text = "You Lost \nPress Space \nTo Restart";
                }
                else {
                    time_Sea_Current -=Time.deltaTime; 
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (tree != null)
                {
                    tree.damage(damage_value);
                }
                text_cut.text = "I'm cutting!";
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                text_cut.text = "";
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (nub_wood > 0)
                {
                    nub_wood--;
                    Instantiate(bridge, transform.position + new Vector3(0, 0, 1.0f), transform.rotation);
                }
            }
        }
        else {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //isStart = true;
                //transform.position = pos_ori;
                text_end.text = "";
                SceneManager.LoadScene("SampleScene");
            }
        }

    }
    public void Movement() {
        isRun = false;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
            isRun = true;
        }

        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            isRun = true;
            transform.position += new Vector3(0.0f, -1.0f * speed * Time.deltaTime, 0.0f);
        }

        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            isRun = true;
            transform.localScale = new Vector3(-1.0f, 1.0f, 0.0f);
            transform.position += new Vector3(-1.0f * speed * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            isRun = true;
            transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }
        animator.SetBool("IsRun", isRun);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Girl")
        {
            isStart = false;
            text_end.text = "You Find Love";
            Debug.Log("Gril!");
        }
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            //Debug.Log("Ground");
        }

        if (collision.gameObject.tag == "Tree")
        {
            tree = collision.gameObject.GetComponent<TreeControl>();
            Debug.Log("Tree");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            tree = null;
            Debug.Log("Tree");
        }
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
            time_Sea_Current = time_Sea;
            //Debug.Log("Ground");
        }
    }



}
