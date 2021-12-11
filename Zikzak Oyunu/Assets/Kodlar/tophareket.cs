using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tophareket : MonoBehaviour
{
    Vector3 yön;
    public float hiz;
    public zemin zeminscrtipti;
    public static bool düþtü_mü;
    public float eklenenhiz;
    void Start()
    {
        yön = Vector3.forward; //oyun basýnda ileri gitme
        düþtü_mü = false;
    }

    
    void Update()
    {
        if(transform.position.y<=0.5f)
        {
            düþtü_mü = true;
        }
        if (düþtü_mü==true)
        {
            Debug.Log("Düþtüm");
            return;
        }
        if (Input.GetMouseButtonDown(0)) // elimi kaldýrana kadar devam eder.
        {
            if (yön.x==0)
            {
                yön = Vector3.left;
            }
            else
            {
                yön = Vector3.forward;
            }
            hiz += eklenenhiz * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Vector3 hareket = yön * Time.deltaTime * hiz;
        transform.position += hareket;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="zemin")
        {
            Skor.skor++;
            collision.gameObject.AddComponent<Rigidbody>();
            zeminscrtipti.zemin_olusur();
            StartCoroutine(ZeminiSil(collision.gameObject));
        }
    }
    IEnumerator ZeminiSil(GameObject silineceZemin)
    {
        yield return new WaitForSeconds(3f);
        Destroy(silineceZemin);
    }
}
