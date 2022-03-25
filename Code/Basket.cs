using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public float speed = 7.0f;

    public float xPos;

    public int lives = 5;
    public int score = 0;

    public GameObject[] gameObjects;

    public GUIStyle myStyle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        xPos = transform.position.x;
        ///print(xPos);
    }
    void MoveCharacter()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (xPos < -5.2)
            {
                speed = 0.0f;
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                speed = 7.0f;
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (xPos > 5.4)
            {
                speed = 0.0f;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                speed = 7.0f;
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }

    void RemovalFruit()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Fruit");
        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
    }

    void RemovalRottom()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Rottom");
        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name=="RotTom(Clone)")
        {
            lives -= 1;
            Destroy(other.gameObject);
            if(lives==0)
            {
                print("GAME OVER");
                RemovalFruit();
                RemovalFruit();
                Time.timeScale = 0;
                SceneManager.LoadScene("GameOver");
            }
        }

        if (other.gameObject.name == "Fruit(Clone)")
        {
            score += 50;
            Destroy(other.gameObject);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(16, 9, 100, 30), "Time: " + Time.time, myStyle);
        GUI.Box(new Rect(16, 27, 100, 30), "Score: " + score);
        GUI.Box(new Rect(16, 45, 100, 30), "Lives: " + lives);
    }
}
