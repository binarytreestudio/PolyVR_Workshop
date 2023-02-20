using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnCollisonEvents : MonoBehaviour
{
    [Tooltip("If this is empty, everything will trigger the events")]
    [SerializeField] List<string> matchTags;
    [SerializeField] UnityEvent<GameObject> onCollisionEnter;
    [SerializeField] UnityEvent<GameObject> onCollisionStay;
    [SerializeField] UnityEvent<GameObject> onCollisionExit;


    private void OnCollisionEnter(Collision collision)
    {
        if (matchTags.Count == 0)
        {
            onCollisionEnter.Invoke(null);
        }
        else
        {
            for (int i = 0; i < matchTags.Count; i++)
            {
                if (collision.gameObject.CompareTag(matchTags[i]))
                {
                    onCollisionEnter.Invoke(null);
                }
            }
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (matchTags.Count == 0)
        {
            onCollisionStay.Invoke(null);
        }
        else
        {
            for (int i = 0; i < matchTags.Count; i++)
            {
                if (collision.gameObject.CompareTag(matchTags[i]))
                {
                    onCollisionStay.Invoke(null);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (matchTags.Count == 0)
        {
            onCollisionExit.Invoke(null);
        }
        else
        {
            for (int i = 0; i < matchTags.Count; i++)
            {
                if (collision.gameObject.CompareTag(matchTags[i]))
                {
                    onCollisionExit.Invoke(null);
                }
            }
        }
    }

}
