using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject raySource;
    [SerializeField] float triggerThreshold = 0.5f;
    MLInput.Controller controller;

    void Start()
    {
        MLInput.Start();
        controller = MLInput.GetController(MLInput.Hand.Left);
    }

    private void OnDestroy()
    {
        MLInput.Stop();
    }

    void Update()
    {
        transform.position = controller.Position;
        transform.rotation = controller.Orientation;

        if (controller.TriggerValue > triggerThreshold)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log(hit.transform.gameObject.name);

                Button button = hit.transform.gameObject.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.Invoke();
                }
            }
        }
    }
}
