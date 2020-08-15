using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    private float moveSpeed;
    private float alphaSpeed;
    private float destroyTime;
    ////TextMeshPro text;
    ////Color alpha;
    ////public string damage;

    public Text text;
    private Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.0f;
        alphaSpeed = 10.0f;
        destroyTime = 5.0f;
        //this.text = GetComponent<Text>();
        /*
        //var gameObj = GameObject.Find("FloatingText");
        this.text = GetComponent<TextMeshPro>();
        alpha = this.text.color;
        this.text.text = damage.ToString();
        Invoke("DestroyObject", destroyTime);
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (this.text == null)
        {
            var gameObj = GameObject.Find("FloatingText");
            this.text = gameObj.GetComponent<TextMeshPro>();
        }

        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0)); // 텍스트 위치

        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); // 텍스트 알파값
        this.text.color = alpha;
        this.text.text = this.damage;
        */

        vector.Set(text.transform.position.x, text.transform.position.y + (moveSpeed + Time.deltaTime), text.transform.position.z);
        this.transform.position = vector;

        destroyTime -= Time.deltaTime;

        if (destroyTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
