using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    public Vector3 jump;
    [SerializeField]  float jumpForce = 3f;
    public bool isGrounded;
    Rigidbody2D rb;
    [SerializeField] GameObject platform; 
    Vector3 platformPos;
    [SerializeField] Text moneyText;
    int count = 0;
    [SerializeField] GameObject win; 


    void Start()
    {
        platformPos = platform.transform.position;
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 2.0f);
    }   
    
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        isGrounded = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "thorn"){
            platform.transform.position = platformPos;
        }
        if (other.tag == "money"){
            ++count;
            moneyText.text = count.ToString();
            Destroy(other.gameObject);
        }
        if (other.tag == "finish"){
            Destroy(platform);
            Destroy(gameObject);
            win.SetActive(true);
        }
    }
}