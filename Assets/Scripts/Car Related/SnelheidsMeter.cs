using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SnelheidsMeter : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects;

    private float maxSpeed = 260f;

    public TMP_Text speedText;

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    public RectTransform arrow;

    public float speed = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        foreach (GameObject target in objects)
        {
            if(target.activeSelf == true)
            {
                target.GetComponent<Rigidbody>();
                speed = target.GetComponent<Rigidbody>().velocity.magnitude * 3.6f;

                if (speedText != null && speed > 0)
              speedText.text = ((int)speed) + "KM/H";

              if (arrow != null)
              arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
 
            }
        }
    }
}
