using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableTest : MonoBehaviour, IUsable
{
    public void Use()
    {
        Debug.Log("Interact");
    }
}
