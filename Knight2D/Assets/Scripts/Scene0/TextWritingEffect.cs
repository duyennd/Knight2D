using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class TextWritingEffect : MonoBehaviour {

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;

    private void Awake() {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        talkingAudioSource = transform.Find("talkingSound").GetComponent<AudioSource>();

        transform.Find("message").GetComponent<Button_UI>().ClickFunc = () => {
            if (textWriterSingle != null && textWriterSingle.IsActive()) {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            } else {
                string[] messageArray = new string[] {
        
              " Chàng chiến binh Akunimo được giao nhiệm vụ đi tìm bản nhạc bị lấy cắp của thiên tài âm nhạc Mokani. Đây là nhiệm vụ đầu tiên nên anh ấy vẫn còn bỡ ngỡ. Hãy đồng hành và giúp đỡ Akunimo vượt qua các chướng ngại vật để đi đến vùng đất Âm nhạc và lấy lại bản nhạc....",
              
                    
                };

                string message = messageArray[Random.Range(0, messageArray.Length)];
                StartTalkingSound();
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .02f, true, true, StopTalkingSound);
            }
        };
    }

    private void StartTalkingSound() {
        talkingAudioSource.Play();
    }

    private void StopTalkingSound() {
        talkingAudioSource.Stop();
    }

    private void Start() {
        //TextWriter.AddWriter_Static(messageText, "This is the assistant speaking, hello and goodbye, see you next time!", .1f, true);
    }

}
