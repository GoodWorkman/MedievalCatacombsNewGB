using UnityEngine;
using UnityEngine.UI;

namespace Player.Old
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;

        private void OnEnable()
        {
            FindObjectOfType<PlayerHealth>().takeDamage += UpdateImage;
        }

        private void UpdateImage(float value)
        {
            _fillImage.fillAmount = value;
        }

        private void OnDisable()
        {
            FindObjectOfType<PlayerHealth>().takeDamage -= UpdateImage;
        }
    }
}
