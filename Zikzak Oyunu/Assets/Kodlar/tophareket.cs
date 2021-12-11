using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tophareket : MonoBehaviour
{
    Vector3 y�n;
    public float hiz;
    public zemin zeminscrtipti;
    public static bool d��t�_m�;
    public float eklenenhiz;
    void Start()
    {
        y�n = Vector3.forward; //oyun bas�nda ileri gitme
        d��t�_m� = false;
    }

    
    void Update()
    {
        if(transform.position.y<=0.5f)
        {
            d��t�_m� = true;
        }
        if (d��t�_m�==true)
        {
            Debug.Log("D��t�m");
            return;
        }
        if (Input.GetMouseButtonDown(0)) // elimi kald�rana kadar devam eder.
        {
            if (y�n.x==0)
            {
                y�n = Vector3.left;
            }
            else
            {
                y�n = Vector3.forward;
            }
            hiz += eklenenhiz * Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Vector3 hareket = y�n * Time.deltaTime * hiz;
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
