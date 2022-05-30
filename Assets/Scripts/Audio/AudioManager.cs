using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//main settingso of the manager
enum TYPE { CONTINUES, RANDOM };
enum STATUS { PLAYING,PAUSED, WAITING }


//the custom class to it in the editor
[System.Serializable]
public class Clips 
{
    //so you can search through music with the beat type
    public enum BEAT { SLOW, NORMAL, FASTPASTE, LO_FI, HARDSTYLE, FRENCHCORE, SOFTCORE, EDM, RELAXING }


    [SerializeField] private string name;
    [SerializeField]public AudioClip clip;
    [SerializeField] private BEAT beat;

    public BEAT getBeat => beat;
    public string getName => name;
}

//the main file of the manager
public class AudioManager : MonoBehaviour
{
    //getting the variables and settings
    [Header("Main OPtions for the Manager")]
    [SerializeField] TYPE TYPE;
    [SerializeField] STATUS STATUS;

    [Header("AudioClips Settings")]
    [Range(5f, 1000f)]
    [SerializeField] float maxWaitingSeconds;
    [SerializeField] float clipTime;
    [SerializeField] int clipPlaying = 0;

    [Header("AudioClips")]
    [SerializeField] Clips[] musicClips;
    [SerializeField] Clips[] sfxClips;

    [Header("Sources")]
    [SerializeField] AudioSource musicSource, sfxSource;
    private static AudioSource sfxS;
    public static Clips[] sfxC;

    void Start()
    {
        sfxS = sfxSource;
        sfxC = sfxClips;
        StartCoroutine(MusicLoop());
    }

    #region Music Loop
    //looping with settings enabled and the correct waiting time before playing new music
    IEnumerator MusicLoop()
    {
        while (true)
        {
            switch (TYPE) 
            {
                case TYPE.CONTINUES:
                    //playing and directly get new music
                    TypeContinues(out clipTime);
                    STATUS = STATUS.PLAYING;
                    yield return new WaitForSecondsRealtime(clipTime);
                    break;
                case TYPE.RANDOM:
                    //playing
                    TypeRandom(out clipTime);
                    STATUS = STATUS.PLAYING;
                    yield return new WaitForSecondsRealtime(clipTime);
                    //waiting till done with the extra random time
                    STATUS = STATUS.WAITING;
                    yield return new WaitForSecondsRealtime(Random.Range(0,maxWaitingSeconds));
                    break;

                default:
                    break;
            }

        }
    }
    //logic for continues music
    void TypeContinues(out float t)
    {
        musicSource.clip = GetClip(clipPlaying);
        musicSource.Play();
        clipPlaying++;
        t = musicSource.time;
    }
    //logic for random ass music
    void TypeRandom(out float t)
    {
        int clip = Random.Range(0,musicClips.Length);
        musicSource.clip = GetClip(clipPlaying);
        musicSource.Play();
        clipPlaying = clip;
        t = musicSource.time;
    }
    #endregion
    #region GET/SET
    AudioClip GetClip(int i)
    {
        return musicClips[i].clip;
    }
    #endregion
    #region Static functions
    public static void PlaySFX(AudioClip clip)
    {
        sfxS.clip = clip;
        sfxS.Play();
    }
    #endregion



}
