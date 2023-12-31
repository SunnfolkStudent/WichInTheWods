using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public class VoiceLinesLoader : MonoBehaviour
{
    public static VoiceLinesLoader instance { get; private set; }
    
    
    public AudioSource audioSource;
    public string voiceLinesFolderPath = "Assets/audio/VoiceLines";

    public Dictionary<string, List<AudioClip>> voiceLinesDictionary = new Dictionary<string, List<AudioClip>>();

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            DestroyImmediate(gameObject);
        
        audioSource = audioSource.GetComponent<AudioSource>();

        //audioSource.volume = 40;
        
        LoadVoiceLines();
        
        Debug.Log("Loaded");
    }

    public void PlayAudioClip(string character, int audioClipIndex)
    {
        audioSource.clip = voiceLinesDictionary[character][audioClipIndex];
        audioSource.Play();
    }

    void LoadVoiceLines()
    {
        string[] subfolders = Directory.GetDirectories(voiceLinesFolderPath);

        foreach (string subfolder in subfolders)
        {
            string folderName = Path.GetFileName(subfolder);
            List<AudioClip> audioClips = new List<AudioClip>();

            string[] audioFiles = Directory.GetFiles(subfolder, "*.wav");

            
            Array.Sort(audioFiles, StringComparer.InvariantCulture);

            foreach (string audioFile in audioFiles)
            {
                
                AudioClip clip = LoadAudioClip(audioFile);
                if (clip != null)
                {
                    audioClips.Add(clip);
                }
            }

            
            voiceLinesDictionary.Add(folderName, audioClips);
        }

        
        if (voiceLinesDictionary.ContainsKey("YourSubfolderName"))
        {
            List<AudioClip> clipsInSubfolder = voiceLinesDictionary["YourSubfolderName"];
            
        }
    }

    AudioClip LoadAudioClip(string filePath)
    {
        
        byte[] audioData = File.ReadAllBytes(filePath);

        
        float[] floatData = new float[audioData.Length / 2];
        for (int i = 0; i < floatData.Length; i++)
        {
            floatData[i] = BitConverter.ToInt16(audioData, i * 2) / 32768.0f;
        }

        AudioClip clip = AudioClip.Create(Path.GetFileNameWithoutExtension(filePath), 
                                          floatData.Length, 1, 88200, false);
        clip.SetData(floatData, 0);
        return clip;
    }
}
