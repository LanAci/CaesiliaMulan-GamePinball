using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Collider bola;

    public Material offMaterial;

    public Material onMaterial;

    private bool isOn;
    private Renderer pog;

    public ScoreManager scoreManager;

    public float score;

    private void Start()
    {
        pog = GetComponent<Renderer>();

        Set(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            Debug.Log("Cling");
            Set(!isOn);
        }
        scoreManager.AddScore(score);

    }
    private void Set(bool active)
    {
        isOn = active;
        if (isOn == true)
        {
            pog.material = onMaterial;
        }
        else
        {
            pog.material = offMaterial;
        }
    }
}
