using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheSimsMini : MonoBehaviour
{
    [Header("Player Needs (0-100)")]
    [Range(0, 100)] public float thirsty = 100f;
    [Range(0, 100)] public float energy = 100f;
    [Range(0, 100)] public float social = 100f;

    [Header("Decrease Speed (per second)")]
    [Range(0, 10)] public float thirstyDecreaseSpeed = 1f;
    [Range(0, 10)] public float energyDecreaseSpeed = 0.5f;
    [Range(0, 10)] public float socialDecreaseSpeed = 0.2f;

    [Header("UI References")]
    public TMP_Text thirstyText;
    public TMP_Text energyText;
    public TMP_Text socialText;

    [Header("Buttons")]
    public Button thirstyButton;
    public Button energyButton;
    public Button socialButton;

    [Header("Animator")]
    public Animator animator;

    private bool isRegeneratingThirsty = false;
    private bool isRegeneratingEnergy = false;
    private bool isRegeneratingSocial = false;

    void Update()
    {
        if (!isRegeneratingThirsty)
            thirsty = Mathf.Max(0, thirsty - thirstyDecreaseSpeed * Time.deltaTime);
        if (!isRegeneratingEnergy)
            energy = Mathf.Max(0, energy - energyDecreaseSpeed * Time.deltaTime);
        if (!isRegeneratingSocial)
            social = Mathf.Max(0, social - socialDecreaseSpeed * Time.deltaTime);

        UpdateUI();
        CheckButtons();
    }

    void UpdateUI()
    {
        if (thirstyText != null) thirstyText.text = $"{Mathf.RoundToInt(thirsty)}";
        if (energyText != null) energyText.text = $"{Mathf.RoundToInt(energy)}";
        if (socialText != null) socialText.text = $"{Mathf.RoundToInt(social)}";
    }

    void CheckButtons()
    {
        thirstyButton.interactable = thirsty <= 50;
        energyButton.interactable = energy <= 50;
        socialButton.interactable = social <= 50;
    }

    public void RegenerateThirsty()
    {
        isRegeneratingThirsty = true;
        animator.SetTrigger("TrDrink");
        StartCoroutine(RegenerateNeed(() => thirsty, value => thirsty = value, () => {
            isRegeneratingThirsty = false;
            animator.SetTrigger("TrIdle");
        }));
    }

    public void RegenerateEnergy()
    {
        isRegeneratingEnergy = true;
        animator.SetTrigger("TrSleep");
        StartCoroutine(RegenerateNeed(() => energy, value => energy = value, () => {
            isRegeneratingEnergy = false;
            animator.SetTrigger("TrIdle");
        }));
    }

    public void RegenerateSocial()
    {
        isRegeneratingSocial = true;
        animator.SetTrigger("TrDance");
        StartCoroutine(RegenerateNeed(() => social, value => social = value, () => {
            isRegeneratingSocial = false;
            animator.SetTrigger("TrIdle");
        }));
    }

    System.Collections.IEnumerator RegenerateNeed(System.Func<float> getNeed, System.Action<float> setNeed, System.Action onComplete)
    {
        while (getNeed() < 100f)
        {
            setNeed(Mathf.Min(100f, getNeed() + 15f * Time.deltaTime));
            yield return null;
        }
        onComplete?.Invoke();
    }
}
