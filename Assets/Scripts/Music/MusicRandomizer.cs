using UnityEngine;

public class MusicRandomizer : MonoBehaviour { 
    [SerializeField] private string[] musicList;
    [SerializeField] private MusicData musicDefault;

    public MusicData GetMusic() {

        MusicData usedMusic;

        if (musicList == null || musicList.Length < 1) //array empty, choosing default
            usedMusic = musicDefault;

        else if (musicList.Length == 1) //only one entry in array
            usedMusic = LoadMusic(musicList[0]);

        else {
            int randMusicId = Random.Range(0, musicList.Length);
            usedMusic = LoadMusic(musicList[randMusicId]);
        }

        if (usedMusic == null) {
            Debug.Log("ERROR: Music could not be loaded! Trying default...");
            usedMusic = musicDefault;
        }
       
        Destroy(this);
        return usedMusic;
    }
    private MusicData LoadMusic(string name){
        string path = "Scriptables/Music/Music";
        string fileName = path+name;

        //load from resources folder
        MusicData loadedMusic = Resources.Load(fileName) as MusicData;

        //check loader null
        if(loadedMusic == null) {
            Debug.Log("ERROR: Music \'"+name+"\' doesnt exist! Path: Resources/"+fileName+". Trying default...");
            return musicDefault;
        }

        return loadedMusic;
    }
}