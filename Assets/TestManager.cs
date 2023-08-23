using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField] SampleController sampleController;
    [SerializeField] Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            sampleController.PlaceAnchorAtRoot();
        }

        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            Instantiate(sampleController.anchorPrefab, cube.position, Quaternion.identity);
        }
    }
}
