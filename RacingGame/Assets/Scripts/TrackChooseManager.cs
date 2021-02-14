using UnityEngine;

public class TrackChooseManager : MonoBehaviour
{
    public static Track CurrentTrack = Track.Asphalt;

    public void SetAsphaltTrack() => CurrentTrack = Track.Asphalt;
    public void SetDirtTrack() => CurrentTrack = Track.Dirt;
}

public enum Track
{
    Asphalt,
    Dirt
}
