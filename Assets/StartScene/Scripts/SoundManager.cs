using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public GameObject SettingSoundBar; // ���� ���� �� ������Ʈ
    [SerializeField] public GameObject OptionSoundBar; // �ɼ� ���� �� ������Ʈ

    private Slider settingMasterSoundSlider;
    private Slider optionMasterSoundSlider;
    private AudioSource masterSound;

    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // �̱��� �ν��Ͻ� ����
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ������Ʈ ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� ������Ʈ ����
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
        audioSource.loop = true; // BGM �ݺ� ���
    }
}
