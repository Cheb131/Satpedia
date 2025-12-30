using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class SkillVoicePlayer : MonoBehaviour
{
    public static SkillVoicePlayer Instance;

    private AudioSource audioSource;

    // nhớ voice vừa phát của mỗi skill
    private Dictionary<SkillConfig, int> lastVoiceIndex = new();

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = 1f;
        audioSource.loop = false;
    }

    // ===== PUBLIC API (CHỈ GỌI HÀM NÀY) =====
    public void PlayFromSkill(SkillConfig skill)
    {
        string url = GetRandomVoice(skill);
        if (string.IsNullOrEmpty(url)) return;

        StopAllCoroutines();
        StartCoroutine(LoadAndPlay(url));
    }

    // ===== PRIVATE LOGIC =====
    private string GetRandomVoice(SkillConfig skill)
    {
        if (skill == null || skill.urlVoice == null || skill.urlVoice.Count == 0)
            return null;

        int last = lastVoiceIndex.TryGetValue(skill, out var i) ? i : -1;
        int rand;

        do
        {
            rand = Random.Range(0, skill.urlVoice.Count);
        }
        while (skill.urlVoice.Count > 1 && rand == last);

        lastVoiceIndex[skill] = rand;
        return skill.urlVoice[rand];
    }

    IEnumerator LoadAndPlay(string url)
    {
        using var req = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Voice load error: " + req.error);
            yield break;
        }

        AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}
