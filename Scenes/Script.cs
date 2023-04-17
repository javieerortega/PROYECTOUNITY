using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public class VideoPlayerController : MonoBehaviour
    {
        public VideoPlayer videoPlayer; // Referencia al componente "VideoPlayer"
        public string videoFilePath; // Ruta del archivo de video

        void Start()
        {
            videoPlayer.url = Application.streamingAssetsPath + "/" + videoFilePath; // Establecer la ruta del archivo de video
            videoPlayer.Play(); // Reproducir el video
        }
    }
}
