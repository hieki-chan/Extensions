using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityE.Extensions.DemoTest
{
    public class ExtensionTests : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("true".ToBool());
            Debug.Log("true1".ToBool());

            Debug.Log(1.ToBool());
            Debug.Log(2.ToBool());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}