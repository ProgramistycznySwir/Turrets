using UnityEngine;

public class NavigationOrganizer : MonoBehaviour {

    private static Transform[] waypointsN;
    public Transform waypointsNParent;
    public static int lastWaypointN, lastWaypointH;

    private static Transform[] waypointsH;
    public Transform waypointsHParent;

    // Use this for initialization
    void Awake ()
    {
        waypointsN = new Transform[waypointsNParent.childCount];
        for (int i = 0; i < waypointsNParent.childCount; i++)
        {
            waypointsN[i] = waypointsNParent.GetChild(i);
        }
        lastWaypointN = waypointsN.Length;

        waypointsH = new Transform[waypointsHParent.childCount];
        for (int i = 0; i < waypointsHParent.childCount; i++)
        {
            waypointsH[i] = waypointsHParent.GetChild(i);
        }
        lastWaypointH = waypointsH.Length;
    }
	public static Transform GetWaypointN(int targetIndex)
    {
        return waypointsN[targetIndex];
    }
    public static Transform GetWaypointH(int targetIndex)
    {
        return waypointsH[targetIndex];
    }
}
