using TMPro;
using UnityEngine;

namespace Chapter.Singleton
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] TextMeshProUGUI firewoodText;
        [SerializeField] GameObject confirmationText;

        void Awake()
        {
            firewoodText.text = "Firewood collected: 0";
            confirmationText.SetActive(false);
        }

        public void UpdateFirewoodText(int total)
        {
            firewoodText.text = $"Firewood collected: {total}";
        }

        public void RevealConfirmText()
        {
            confirmationText?.SetActive(true);
        }

    }
}
