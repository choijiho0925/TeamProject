using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public GameObject SettingSoundBar; // 세팅 사운드 바 오브젝트
    [SerializeField] public GameObject OptionSoundBar; // 옵션 사운드 바 오브젝트

    private Slider settingMasterSoundSlider;
    private Slider optionMasterSoundSlider;
    private AudioSource masterSound;

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 싱글톤 인스턴스 설정
            DontDestroyOnLoad(gameObject); // 씬 전환 시 오브젝트 유지
        }
        else
        {
            Destroy(gameObject); // 중복된 오브젝트 삭제
        }
    }

    private void Start()
    {
        masterSound = GetComponentInChildren<AudioSource>();
        settingMasterSoundSlider = SettingSoundBar.GetComponentInChildren<Slider>();
        optionMasterSoundSlider = OptionSoundBar.GetComponentInChildren<Slider>();

        Init();

        settingMasterSoundSlider.onValueChanged.AddListener(SetVolume);
        optionMasterSoundSlider.onValueChanged.AddListener(SetVolume);
    }
    private void Update()
    {
        settingMasterSoundSlider.value = masterSound.volume;
        optionMasterSoundSlider.value = masterSound.volume;
    }

    public void Init()
    {
        if (settingMasterSoundSlider != null)
        {
            settingMasterSoundSlider.maxValue = 1;
            settingMasterSoundSlider.minValue = 0.0001f;
            settingMasterSoundSlider.value = masterSound.volume;
        }

        if (optionMasterSoundSlider != null)
        {
            optionMasterSoundSlider.maxValue = 1;
            optionMasterSoundSlider.minValue = 0.0001f;
            optionMasterSoundSlider.value = masterSound.volume;
        }
    }

    public void SetVolume(float value)
    {
        masterSound.volume = value;
    }

    public void PlayBGM(AudioClip clip)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        audioSource.loop = true; // BGM 반복 재생
    }
}
