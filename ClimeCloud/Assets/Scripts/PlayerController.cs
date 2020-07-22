using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject clearPanel;
    Animator animator;
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;
    float walkForce = 10.0f;
    float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        clearPanel = GameObject.Find("Panel");
        clearPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)&& this.rigid2D.velocity.y == 0)
        if ((Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0) || (Input.GetMouseButtonDown(0)&& this.rigid2D.velocity.y == 0))
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = 2;
        if(Input.GetKey(KeyCode.LeftArrow)) key = -2;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0)
        {
            transform.localScale = new Vector3(key, 2, 2);
        }

        // 플레이어 속도에 맞춰 애니메이션 속도를 바꾼다
        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // 플레이어가 화면 밖으로 나갔다면 처음부터
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }

    }
    // 목표 지점 도착
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골");
        clearPanel.SetActive(true);
        // SceneManager.LoadScene("ClearScene");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "flower")
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("flower");
            for (int i = 0; i < obj.Length; i++)
                Destroy(obj[i]);
            GameObject[] obj2 = GameObject.FindGameObjectsWithTag("bomb");
            for (int i = 0; i < obj2.Length; i++)
                Destroy(obj2[i]);
        }
        if (collision.gameObject.tag == "flower2")
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("flower2");
            for (int i = 0; i < obj.Length; i++)
                Destroy(obj[i]);
            GameObject[] obj2 = GameObject.FindGameObjectsWithTag("bomb2");
            for (int i = 0; i < obj2.Length; i++)
                Destroy(obj2[i]);
        }
        if (collision.gameObject.tag == "flowe3")
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("flowe3");
            for (int i = 0; i < obj.Length; i++)
                Destroy(obj[i]);
            GameObject[] obj2 = GameObject.FindGameObjectsWithTag("bomb3");
            for (int i = 0; i < obj2.Length; i++)
                Destroy(obj2[i]);
        }
        else if(collision.gameObject.tag == "bomb")
        {
            SceneManager.LoadScene("ClearScene");
        }
        else if (collision.gameObject.tag == "bomb2")
        {
            SceneManager.LoadScene("ClearScene");
        }
        else if (collision.gameObject.tag == "bomb3")
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
