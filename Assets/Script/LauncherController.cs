using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public Collider bola;
    
    public KeyCode input;

    public float force;

    public float maxTimeHold;

    public float maxForce;

    private bool isHold;

    private void Start()
    {
        isHold = false;
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
            {
                ReadInput(bola);
            }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input))
        {
            collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        }
        if (Input.GetKey(input) && !isHold)
            {
                StartCoroutine(StartHold(collider));
            }
    }

    //coroutine buat fitur hold launcher
    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
    {
        //hitung force pake Lerp
        force =Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);

        //tunggu step berikutnya dan naikin timer
        //agar dapat force yg lebih besar dari sebelumnya
        yield return new WaitForEndOfFrame();
        timeHold += Time.deltaTime;
    }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
}
}
