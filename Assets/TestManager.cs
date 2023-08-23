using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestManager : MonoBehaviour
{
    [SerializeField] SampleController sampleController;
    [SerializeField] Transform cube;
    [SerializeField] PhotonAnchorManager photonAnchorManager;

    // Start is called before the first frame update
    void Start()
    {
        UserIDsList();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetKeyDown(KeyCode.X))
        {
            UserIDsList();
        }

        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            Instantiate(sampleController.anchorPrefab, cube.position, Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            photonAnchorManager.OnCreateRoomButtonPressed();
        }
    }

    void UserIDsList()
    {
        var userIds = PhotonAnchorManager.GetUserList().Select(userId => userId.ToString()).ToArray();
        ICollection<OVRSpaceUser> spaceUserList = new List<OVRSpaceUser>();
        foreach (string strUsername in userIds)
        {
            spaceUserList.Add(new OVRSpaceUser(ulong.Parse(strUsername)));
            Debug.Log("1: ------------------------------------------\n" + spaceUserList);
        }

        Debug.Log("2: ------------------------------------------\n" + userIds[0]);
    }
}
