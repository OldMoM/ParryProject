using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;

    public Text healthText;
    public Image healthImage;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void UpdatePlayerAttribute(PlayerAttribute m_attribute)
    {
        healthImage.fillAmount = m_attribute.current_health / m_attribute.max_health;
        healthText.text = m_attribute.current_health + "/" + m_attribute.max_health;
    }
}
